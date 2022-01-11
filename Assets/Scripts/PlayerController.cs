using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : Charactor
{
    // Start is called before the first frame update
    [SerializeField] Transform charactorBody;
    [SerializeField] Transform cameraArm;
    [SerializeField] GameObject sword1;
    [SerializeField] GameObject sword2;
    [SerializeField] GameObject skill;
    [SerializeField] float moveSpeed;
    //[SerializeField] float hp;
    //[SerializeField] float maxHp;
    //[SerializeField] float stamina = 100;
    //[SerializeField] float maxMp;
    //public static float mp;
    //public static float hpRate = 1f;
    //public static float mpRate = 1f;
    //public static float staminaRate = 1f;

    bool isEquip;
    bool isAttack = true;
    bool isDie;
    bool isDive;
    Animator animator;
    public Action endAttackAnimeListner;
    void Start()
    {
        animator = charactorBody.GetComponent<Animator>();
        sword2.SetActive(false);
        StartCoroutine(HealRecovery());
        StartCoroutine(UsingSkill());
        //hp = 100;
        maxHp = hp;
        mp = maxMp;
        att = 5 + SwordAttack.swordAtt;

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

            charactorBody.forward = moveDir;
            transform.position += moveDir * Time.deltaTime * moveSpeed;
        }
    }

    void Update()
    {
        hpRate = hp / maxHp;
        mpRate = mp / maxMp;
        staminaRate = stamina / 100;
        att = 5 + SwordAttack.swordAtt;
        if (isAttack)
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
            if (isEquip)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isDive = true;
                    animator.Play("tumbling");
                    stamina -= 20;
                }
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
            if (!isDive)
            {
                //animator.Play("Hit");
                hp -= collision.other.gameObject.GetComponent<Monster>().att;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MonsterWeapon")
        {
            hp -= other.GetComponentInParent<Monster>().skillAtt;
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

    void IsDive()
    {
        isDive = false;
    }
    void Attack()
    {
        sword2.GetComponent<BoxCollider>().enabled = true;
        Debug.Log("att");
    }
    void EndAttack()
    {
        sword2.GetComponent<BoxCollider>().enabled = false;
        if(endAttackAnimeListner != null)
            endAttackAnimeListner();
        endAttackAnimeListner = null;
        Debug.Log("end");
    }
    void StartAttAnim()
    {
        isAttack = false;
    }
    void EndAttAnim()
    {
        isAttack = true;
    }

    IEnumerator HealRecovery()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (stamina < 100)
            {

                stamina += 1;
            }
            if(mp < maxMp && !skill.gameObject.activeSelf)
            {
                mp += 1;
            }
        }
    }
    IEnumerator UsingSkill()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (mp > 0)
            {
                if (skill.gameObject.activeSelf)
                {
                    if (mp <= 10)
                    {
                        mp = 0;
                    }
                    else
                    {
                        mp -= 10;
                    }

                }
            }
        }
    }
}

