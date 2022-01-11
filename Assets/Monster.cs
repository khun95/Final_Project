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
    public bool isDie;
    public bool isAttack;
    public int att;
    public int skillAtt;
    public Slider hpBar;
    public NavMeshAgent navAgent;
    public GameObject player;
    public Action<Transform> dangerNotificationEvent;

    public Animator animator;
    public enum Attribute
    {
        Fire,
        Wind,
        Water,
        Light
    }
    public void HitRelease()
    {
        isHit = false;
    }
    public void DieCheck()
    {
        isDie = true;
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
            if(isDie)
                Destroy(gameObject);
        }
    }

    private void Start()
    {
        dangerNotificationEvent += SetDestination;
    }

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
                isHit = true;
                animator.Play("Hit");
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
