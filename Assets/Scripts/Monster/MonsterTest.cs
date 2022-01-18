using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterTest : Monster
{
    // Start is called before the first frame update
    
    private void Start()
    {
        hp = 100;
        maxHp = hp;
        att = 20;
    }
   
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Sword")
    //    {
    //        if(isHit == false)
    //        {
    //            FindObjectOfType<PlayerController>().endAttackAnimeListner += HitRelease;
    //            hp -= GameObject.FindGameObjectWithTag("Player").GetComponent<Charactor>().att;
    //            isHit = true;
    //        }
    //    }
    //}
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hp : " + hp);
        HPCheck();
        Die();
    }
}
