using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SkeletonMage : Monster
{
    public GameObject charactor;
    public GameObject ball;
    public GameObject ballPos;
    ////public bool isSpawn = false;
    //public bool isEnter = false;
    //Vector3 originPos;
    public Attribute Attribute;
    private new void Start()
    {
        base.Start();
        monsterType = 2;

    }
    void ShootingBall()
    {
        GameObject temp = Instantiate(ball, ballPos.transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().att = skillAtt;
    }
    void Update()
    {
        HPCheck();
        Die();
        MonsterMove(player, 10, 10, 15);
        //if (isSpawn)
        //{

        //    if (Vector3.Distance(gameObject.transform.position, charactor.transform.position) <= 10)
        //    {
        //        isEnter = true;
        //    }

        //    if (isEnter)
        //    {
        //        animator.SetBool("isRun", true);
        //        navAgent.SetDestination(charactor.transform.position);
        //    }

        //    if (Vector3.Distance(gameObject.transform.position, originPos) > 20 && isEnter)
        //    {
        //        navAgent.SetDestination(originPos);
        //        isEnter = false;
        //    }

        //    if (Vector3.Distance(gameObject.transform.position, originPos) < 2)
        //    {
        //        animator.SetBool("isRun", false);
        //    }

        //}

        //if (Vector3.Distance(gameObject.transform.position, charactor.transform.position) <= 15)
        //{
        //    gameObject.transform.LookAt(charactor.transform);
        //    animator.SetTrigger("isAttack");
        //}
    }

}
