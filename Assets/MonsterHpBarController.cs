using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterHpBarController : MonoBehaviour
{
    public GameObject player;
    public Slider hpbar;
    public float maxHp;
    public float currentHp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.position + new Vector3(0, 0, 0);
        currentHp = player.GetComponent<MonsterTest>().hp;
        maxHp = player.GetComponent<MonsterTest>().maxHp;
        hpbar.value = currentHp / maxHp;
    }
}
