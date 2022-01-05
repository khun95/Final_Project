using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterTest : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp = 100;
    public float maxHp;
    bool isHit = false;
    public Slider hpBar;
    private void Start()
    {
        maxHp = hp;
    }
    public void HitRelease()
    {
        isHit = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sword")
        {
            if(isHit == false)
            {
                FindObjectOfType<PlayerController>().endAttackAnimeListner += HitRelease;
                hp -= 10;
                isHit = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hp : " + hp);
        if (hp <= 0)
        {
            hpBar.gameObject.SetActive(false);
        }
        else
        {
            hpBar.value = hp / maxHp;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
