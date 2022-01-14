using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.AI;
public class Monster : MonoBehaviour
{
    // Start is called before the first frame update

    public float hp;
    public float maxHp;
    public bool isHit = false;
    public bool isIdle;
    public bool isDie;
    public bool isSpawn = false;
    public bool isAttack;
    public bool isChase;
    public bool isEnter = false;
    public bool isOrigin;
    public int att;
    public int skillAtt;
    public Slider hpBar;
    public NavMeshAgent navAgent;
    public GameObject player;
    public Action<Transform> dangerNotificationEvent;
    public Animator animator;
    public int monsterType;
    public Vector3 originPos;
    public Vector3 prevPos;
    public GameObject coin;
    public int coinCount;
    public enum Attribute
    {
        Fire,
        Wind,
        Water,
        Light
    }
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
    public void CheckIdle()
    {
        isIdle = true;
    }
    public void HitStart()
    {
        isHit = true;
    }
    public void HitRelease()
    {
        isHit = false;
    }
    public void DieCheck()
    {
        isDie = true;
    }
    public void CheckSpawn()
    {
        isSpawn = true;
    }
    public void CheckAttack()
    {
        isAttack = true;
    }
    public void CheckAttackEnd()
    {
        isAttack = false;
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

    public void MonsterMove(GameObject charactor, float chaseRange, float backRange, float attackRange)
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
    public void StartAttack()
    {
        GameObject.FindGameObjectWithTag("MonsterWeapon").GetComponent<BoxCollider>().enabled = true;
        Debug.Log("start att");
    }
    public void EndAttack()
    {
        GameObject.FindGameObjectWithTag("MonsterWeapon").GetComponent<BoxCollider>().enabled = false;
        Debug.Log("end att");
    }
    public void Die() {
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
    //if(hp <= 0)
    //{
    //    isHit = true;
    //    animator.Play("Die");
    //    hpBar.gameObject.SetActive(false);
    //    navAgent.enabled = false;
    //    Die();
    //}

    public void SetDestination(Transform target)
    {
        GetComponent<NavMeshAgent>().SetDestination(target.position);
    }

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

    //public IEnumerator FindPlayer()
    //{
    //    navAgent.enabled = true;
    //    while (navAgent.SetDestination(player.transform.position))
    //    {
    //        yield return null;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {

    }
}
