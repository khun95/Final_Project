using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonArcher : Monster
{
    // Start is called before the first frame update
    public GameObject charactor;
    public GameObject arrow;
    public bool isSpawn = false;
    public bool isEnter = false;
    public Attribute Attribute;
    Vector3 originPos;
    private void Start()
    {
        hp = 100;
        maxHp = hp;
        att = 5;
        skillAtt = 10;
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        originPos = gameObject.transform.position;
        charactor = GameObject.FindGameObjectWithTag("Player");
        //StartCoroutine(FindPlayer(chcaractor.transform.position));

    }
    void CheckSpawn()
    {
        isSpawn = true;
    }
    // Update is called once per frame
    void Update()
    {
        HPCheck();
        Debug.Log(Vector3.Distance(gameObject.transform.position, originPos));
        if (hp <= 0)
        {
            isHit = true;
            animator.Play("Die");
            hpBar.gameObject.SetActive(false);
            navAgent.enabled = false;
            Die();  
        }
        if (isSpawn)
        {

            if (Vector3.Distance(gameObject.transform.position, charactor.transform.position) <= 10)
            {
                isEnter = true;
            }

            if (isEnter)
            {
                animator.SetBool("isRun", true);
                navAgent.SetDestination(charactor.transform.position);
            }

            if (Vector3.Distance(gameObject.transform.position, originPos) > 20 && isEnter)
            {
                navAgent.SetDestination(originPos);
                isEnter = false;
            }

            if (Vector3.Distance(gameObject.transform.position, originPos) < 2)
            {
                animator.SetBool("isRun", false);
            }

        }

        if (Vector3.Distance(gameObject.transform.position, charactor.transform.position) <= 5)
        {
            animator.SetTrigger("isAttack");
        }


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

