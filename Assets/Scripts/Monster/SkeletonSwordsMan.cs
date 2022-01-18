using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
public class SkeletonSwordsMan : Monster
{
        // Start is called before the first frame update
        public GameObject charactor;

        public Attribute Attribute;
        private void Start()
        {
            base.Start();
            monsterType = 1;
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


