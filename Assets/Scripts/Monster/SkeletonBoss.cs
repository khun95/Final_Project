using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class SkeletonBoss : Monster
{
    // Start is called before the first frame update
    [SerializeField] GameObject berserkeEffect;
    [SerializeField] GameObject skill1;
    [SerializeField] Attribute Attribute;
    bool isUseSkill;
    private void Start()
    {
        base.Start();
        monsterType = 3;
    }
    void UseSkill1()
    {
        skill1.SetActive(true);
    }
    void EndSkill1()
    {
        skill1.SetActive(false);
    }
    void Berserke()
    {
        att = 100;
        skillAtt = 200;
        berserkeEffect.SetActive(true);
    }
    public virtual void Die()
    {
        if (hp <= 0)
        {
            coin.GetComponent<Coin>().coinValue = coinCount;
            coin.SetActive(true);
            isHit = true;
            animator.Play("Die");
            hpBar.gameObject.SetActive(false);
            navAgent.enabled = false;
            if (isDie)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("BossClear");
            }
        }
    }
    public void BossCoin()
    {
        Charactor.money += 1000;
    }
    // Update is called once per frame
    void Update()
    {
        HPCheck();
        Die();

        MonsterMove(player, 5, 20, 3);
        if (BerserkeBarTimeController.isBerserk)
        {
            Berserke();
        }
        if(hp <= 900)
        {
            if (!isUseSkill)
            {
                animator.Play("Spell1");
                isUseSkill = true;
            }
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Spell1"))
        {
            isHit = true;
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
