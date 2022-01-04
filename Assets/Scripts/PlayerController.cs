using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform charactorBody;
    [SerializeField] Transform cameraArm;
    [SerializeField] float moveSpeed;
    Animator animator;
    public static bool isLoaded;
    bool isEquip;
    bool isMove;
    public GameObject sword1;
    public GameObject sword2;
    public Action endAttackAnimeListner;


    void Start()
    {
        animator = charactorBody.GetComponent<Animator>();
        sword2.SetActive(false);
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
        if (!isMove)
        {
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
}
