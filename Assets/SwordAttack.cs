using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SwordAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public int att = 10;
    [SerializeField] GameObject effect;
    [SerializeField] Slider mainHpBar;
    GameObject monster;
    bool isDead;
    [SerializeField] TextMeshProUGUI monsterName;
    void Start()
    {
        mainHpBar.gameObject.SetActive(false);
    }
    void EffectOff()
    {
        effect.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
        {
            effect.SetActive(true);
            FindObjectOfType<PlayerController>().endAttackAnimeListner += EffectOff;
            if (isDead)
            {
                monster = other.gameObject;
                mainHpBar.gameObject.SetActive(true);
                monsterName.gameObject.SetActive(true);
                monsterName.text = monster.gameObject.name;
                isDead = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (monster == null)
        {
            monsterName.gameObject.SetActive(false);
            mainHpBar.gameObject.SetActive(false);
            isDead = true;
        }
        else
        {
            mainHpBar.value = monster.GetComponent<MonsterTest>().hpBar.value;
        }
    }
}
