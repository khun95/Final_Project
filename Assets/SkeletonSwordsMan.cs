using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
public class SkeletonSwordsMan : Monster
{
    // Start is called before the first frame update
    public GameObject charactor;
    //public bool isSpawn = false;
    //public bool isEnter = false;
    //Vector3 originPos;
    public Attribute Attribute;
    
    //Vector3 prevPos;
    private void Start()
    {
        base.Start();
        monsterType = 1;
        //maxHp = hp;
        //animator = GetComponent<Animator>();
        //navAgent = GetComponent<NavMeshAgent>();
        //originPos = gameObject.transform.position;
        //charactor = GameObject.FindGameObjectWithTag("Player");
    }
    IEnumerator WaitForMove()
    {
        yield return new WaitForSeconds(1f);
    }
    // Update is called once per frame
    void Update()
    {
        HPCheck();
        Die();
        MonsterMove(player, 5, 20, 2);
        //if (isSpawn)
        //{

        //    if (Vector3.Distance(gameObject.transform.position, charactor.transform.position) <= 5)
        //    {
        //        isEnter = true;
        //    }

        //    if (isEnter)
        //    {
        //        animator.SetBool("isRun", true);
        //        navAgent.SetDestination(charactor.transform.position);
        //    }

        //    if (Vector3.Distance(gameObject.transform.position, originPos) > 10 && isEnter)
        //    {
        //        navAgent.SetDestination(originPos);
        //        isEnter = false;
        //    }

        //    if (Vector3.Distance(gameObject.transform.position, originPos) < 0.2)
        //    {
        //        animator.SetBool("isRun", false);
        //    }

        //}

        //if(Vector3.Distance(gameObject.transform.position, charactor.transform.position) <= 2)
        //{
        //    animator.SetTrigger("isAttack");
        //}

       

        //if (isSpawn)
        //{
        //    if (Vector3.Distance(gameObject.transform.position, originPos) > 10 && isEnter) // 원래자리보다 멀어질경우
        //    {
        //        isEnter = false;
        //        animator.ResetTrigger("isAttack");
        //        gameObject.transform.LookAt(originPos);
        //        navAgent.SetDestination(originPos);
        //        Debug.Log("back");

        //    }
        //    else if (Vector3.Distance(gameObject.transform.position, charactor.transform.position) <= 5)
        //    {
        //        isEnter = true;
        //    }


        //    if (isEnter)
        //    {
        //        animator.SetBool("isRun", true);
        //        navAgent.SetDestination(charactor.transform.position);
        //        Debug.Log("chase");
        //    }


        //    if (Vector3.Distance(gameObject.transform.position, originPos) < 2) // 원래 자리로돌아 갔을경우
        //    {
        //        animator.SetBool("isRun", false);
        //    }

        //}
        //if (Vector3.Distance(gameObject.transform.position, charactor.transform.position) <= 3) // 공격 범위
        //{
        //    Debug.Log("att");
        //    gameObject.transform.LookAt(charactor.transform);
        //    animator.SetTrigger("isAttack");   
        //}

        //if(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        //{
        //    transform.position = prevPos;
        //}

        //prevPos = transform.position;


    }






    IEnumerator FindPlayer(Vector3 target)
    {
        navAgent.enabled = true;
        while (navAgent.SetDestination(target))
        {
            animator.SetBool("isRun", true);
            yield return null;
        }
    }

}


