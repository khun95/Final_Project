using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonArcher : Monster
{
    // Start is called before the first frame update

    [SerializeField] GameObject arrow;
    [SerializeField] GameObject arrowPos;

    public Attribute Attribute;
    private void Start()
    {
        base.Start();
        monsterType = 2;

    }
    void ShootingArrow()
    {
        isAttack = true;
        GameObject temp = Instantiate(arrow, arrowPos.transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().att = skillAtt;
    }
    // Update is called once per frame
    void Update()
    {
        HPCheck();
        Die();
        MonsterMove(player, 10, 10, 15);
    //    if (isSpawn)
    //    {
    //        if (Vector3.Distance(gameObject.transform.position, originPos) > 10 && isEnter) // 원래자리보다 멀어질경우
    //        {
    //            isEnter = false;
    //            navAgent.SetDestination(originPos);
    //            Debug.Log("back");
    //        }
    //        else if (Vector3.Distance(gameObject.transform.position, charactor.transform.position) <= 20)
    //        {
    //            isEnter = true;
    //        }


    //        if (isEnter)
    //        {
    //            animator.SetBool("isRun", true);
    //            navAgent.SetDestination(charactor.transform.position);
    //            Debug.Log("chase");
    //        }


    //        if (Vector3.Distance(gameObject.transform.position, originPos) < 2) // 원래 자리로돌아 갔을경우
    //        {
    //            animator.SetBool("isRun", false);
    //        }

    //    }
    //    if (Vector3.Distance(gameObject.transform.position, charactor.transform.position) <= 15) // 공격 범위
    //    {
    //        gameObject.transform.LookAt(charactor.transform);
    //        animator.SetTrigger("isAttack");
    //    }
    }
}


