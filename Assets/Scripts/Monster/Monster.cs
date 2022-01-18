using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.AI;
public class Monster : MonoBehaviour
{
    // Start is called before the first frame update

    public enum Attribute
    {
        Fire,
        Wind,
        Water,
        Light
    }
    public float hp;
    protected float maxHp;
    public int att;
    public int skillAtt;
    public GameObject coin;
    public int coinCount;
    public Slider hpBar;
    public bool isHit = false;
    public bool isEnter = false;
    protected NavMeshAgent navAgent;
    protected GameObject player;
    protected Action<Transform> dangerNotificationEvent;
    protected Animator animator;
    protected int monsterType;
    protected Vector3 originPos;
    protected Vector3 prevPos;
    protected bool isOrigin;
    protected bool isIdle;
    protected bool isDie;
    protected bool isSpawn = false;
    protected bool isAttack;
    protected bool isChase;
    public void Start()
    {
        //dangerNotificationEvent += SetDestination;
        maxHp = hp;
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        originPos = gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(HealRecovery());
    }
    protected void CheckIdle()
    {
        isIdle = true;
    }
    protected void HitStart()
    {
        isHit = true;
    }
    protected void HitRelease()
    {
        isHit = false;
    }
    protected void DieCheck()
    {
        isDie = true;
    }
    protected void CheckSpawn()
    {
        isSpawn = true;
    }
    protected void CheckAttack()
    {
        isAttack = true;
    }
    protected void CheckAttackEnd()
    {
        isAttack = false;
    }
    protected void StartAttack()
    {
        GameObject.FindGameObjectWithTag("MonsterWeapon").GetComponent<BoxCollider>().enabled = true;
        Debug.Log("start att");
    }
    protected void EndAttack()
    {
        GameObject.FindGameObjectWithTag("MonsterWeapon").GetComponent<BoxCollider>().enabled = false;
        Debug.Log("end att");
    }
    public virtual void Die() {
        if (hp <= 0)
        {
            coin.GetComponent<Coin>().coinValue = coinCount;
            coin.SetActive(true);
            isHit = true;
            animator.Play("Die");
            hpBar.gameObject.SetActive(false);
            navAgent.enabled = false;
            if (isDie)
                Destroy(gameObject);
        }
    }
    IEnumerator HealRecovery()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (isOrigin)
            {
                if (isIdle)
                {
                    if (hp < maxHp)
                    {
                        hp += 10;
                        if (hp > maxHp)
                        {
                            hp = maxHp;
                        }
                    }
                }
            }
        }
    }

    protected void MonsterMove(GameObject charactor, float chaseRange, float backRange, float attackRange)
    {
        //Debug.Log(Vector3.Distance(gameObject.transform.position, originPos));
        if (isSpawn)
        {
            //if (Vector3.Distance(gameObject.transform.position, originPos) > 10 && isEnter) // 원래자리보다 멀어질경우
            //{
            //    isEnter = false;
            //    navAgent.SetDestination(originPos);
            //    Debug.Log("back");
            //}
            //else if (Vector3.Distance(gameObject.transform.position, charactor.transform.position) <= 20)
            //{
            //    isEnter = true;
            //}

            if (Vector3.Distance(gameObject.transform.position, originPos) > backRange && isEnter)// 원래자리보다 멀어질경우
            {
                isEnter = false;
                animator.ResetTrigger("isAttack");
                navAgent.stoppingDistance = 0.1f;
                gameObject.transform.LookAt(originPos);
                navAgent.SetDestination(originPos);
            }
            else if (Vector3.Distance(gameObject.transform.position, charactor.transform.position) <= chaseRange) //접근범위
            {
                isEnter = true;
                isOrigin = false;
                isIdle = false;
            }

            if (isEnter)
            {
                gameObject.transform.LookAt(charactor.transform);
                animator.SetBool("isRun", true);
                if (monsterType == 1)
                {
                    navAgent.stoppingDistance = 2f;
                }
                else if (monsterType == 2)
                {
                    navAgent.stoppingDistance = 5f;
                }
                else if (monsterType == 3)
                {
                    navAgent.stoppingDistance = 3f;
                }
                navAgent.SetDestination(charactor.transform.position);
            }


            if (Vector3.Distance(gameObject.transform.position, originPos) < 1)// 원래 자리로돌아 갔을경우
            {
                animator.SetBool("isRun", false);
                isOrigin = true;
            }
        }
        if (Vector3.Distance(gameObject.transform.position, charactor.transform.position) <= attackRange) // 공격 범위
        {
            gameObject.transform.LookAt(charactor.transform);
            animator.SetTrigger("isAttack");
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") || animator.GetCurrentAnimatorStateInfo(0).IsName("Spell1"))
        {
            transform.position = prevPos;
            isIdle = false;
        }

        prevPos = transform.position;
    }
    //if(hp <= 0)
    //{
    //    isHit = true;
    //    animator.Play("Die");
    //    hpBar.gameObject.SetActive(false);
    //    navAgent.enabled = false;
    //    Die();
    //}

    //public void SetDestination(Transform target)
    //{
    //    GetComponent<NavMeshAgent>().SetDestination(target.position);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            if (isHit == false)
            {
                FindObjectOfType<PlayerController>().endAttackAnimeListner += HitRelease;
                hp -= GameObject.FindGameObjectWithTag("Player").GetComponent<Charactor>().att;
                animator.Play("Hit");
                isHit = true;
            }
        }
    }
    public void HPCheck()
    {
        if (hp <= 0)
        {
            hpBar.gameObject.SetActive(false);
        }
        else
        {
            hpBar.value = hp / maxHp;
        }
    }
}
