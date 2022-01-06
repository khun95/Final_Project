using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform charactorBody;
    [SerializeField] Transform cameraArm;
    [SerializeField] GameObject sword1;
    [SerializeField] GameObject sword2;
    [SerializeField] float moveSpeed;
    [SerializeField] float hp;
    [SerializeField] float maxHp;
    [SerializeField] float stamina = 100;
    Animator animator;
    public static bool isLoaded;
    public static float hpRate = 1f;
    public static float staminaRate = 1f;
    bool isEquip;
    bool isMove;
    bool isDie;
    public Action endAttackAnimeListner;
    void Start()
    {
        animator = charactorBody.GetComponent<Animator>();
        sword2.SetActive(false);
        StartCoroutine(StaminaHeal());
    }
    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        animator.SetBool("isWalk", isMove);
        if (isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            charactorBody.forward = lookForward;
            transform.position += moveDir * Time.deltaTime * moveSpeed;
        }
        //Debug.DrawRay(cameraArm.position, cameraArm.forward, Color.red);
    }
    // Update is called once per frame
    void Update()
    {
        hpRate = hp/maxHp;
        staminaRate = stamina / 100;
        if (!isMove)
        {
            if (!isEquip)
            {
                moveSpeed = 8;
            }
            else
            {
                moveSpeed = 5;
            }
            Move();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            animator.SetBool("isEquip", false);
            isEquip = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isEquip)
            {
                animator.SetBool("isEquip", true);
                isEquip = true;
            }
            else
            {
                    animator.SetTrigger("isSlash1");
            }
        }
        if (stamina >= 20)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.Play("tumbling");
                stamina -= 20;
            }
        }
        if (!isDie)
        {
            if (hp <= 0)
            {
                animator.Play("Die");
                isDie = true;
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.tag == "Monster")
        {
            //animator.Play("Hit");
            hp -= 10;
        }
    }
    void Equip()
    {
        sword1.SetActive(false);
        sword2.SetActive(true);
    }
    void UnEquip()
    {
        sword2.SetActive(false);
        sword1.SetActive(true);
    }

    void Attack()
    {
        sword2.GetComponent<BoxCollider>().enabled = true;
        Debug.Log("att");
    }
    void EndAttack()
    {
        sword2.GetComponent<BoxCollider>().enabled = false;
        endAttackAnimeListner();
        endAttackAnimeListner = null;
        Debug.Log("end");
    }

    IEnumerator StaminaHeal()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (stamina < 100)
            {

                stamina += 1;
            }
        }

    }
}

