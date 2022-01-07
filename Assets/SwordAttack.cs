using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SwordAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public int att = 10;
    [SerializeField] GameObject effectPos;
    [SerializeField] GameObject effect;
    [SerializeField] GameObject effectFactory;
    [SerializeField] GameObject enchant;
    [SerializeField] Slider mainHpBar;
    [SerializeField] List<GameObject> effectPooling;
    [SerializeField] int poolingIndex = 0;
    [SerializeField] int poolingNum = 0;
    GameObject monster;
    bool isDead;
    bool isEnchant;
    [SerializeField] TextMeshProUGUI monsterName;

    private void Awake()
    {
        //poolingNum = 5;
        effectPooling = new List<GameObject>();
        for (int i = 0; i < poolingNum; i++)
        {
            GameObject temp = Instantiate(effect, effect.transform.position, Quaternion.identity);
            temp.transform.SetParent(effectFactory.transform);
            temp.SetActive(false);
            effectPooling.Add(temp);
        }
    }
    void Start()
    {

        mainHpBar.gameObject.SetActive(false);
    }
    void EffectOff()
    {
        effectPooling[poolingIndex].SetActive(false);
        Debug.Log("EffectOff Test È£Ãâ" + poolingIndex);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
        {
            if (!other.GetComponent<MonsterTest>().isHit)
            {

                effectPooling[poolingIndex].SetActive(true);
                effectPooling[poolingIndex].gameObject.transform.position = effectPos.gameObject.transform.position;
                StartCoroutine(EffectsObjectPooling(poolingIndex));
                // FindObjectOfType<PlayerController>().endAttackAnimeListner += EffectOff;
                poolingIndex++;

            }
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
        if (poolingIndex >= poolingNum)
            poolingIndex = 0;

        if (PlayerController.mp <= 0)
        {
            isEnchant = false;
            enchant.SetActive(isEnchant);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(PlayerController.mp >= 10)
            {

                isEnchant = !isEnchant;
                enchant.SetActive(isEnchant);
            }
            
        }
        if (monster == null)
        {
            //monsterName.gameObject.SetActive(false);
            mainHpBar.gameObject.SetActive(false);
            isDead = true;
        }
        else
        {
            mainHpBar.value = monster.GetComponent<MonsterTest>().hpBar.value;
        }
    }

    IEnumerator EffectsObjectPooling(int tempPoolingIndex)
    {

  
        Debug.Log(effectPooling[tempPoolingIndex].name);

        yield return new WaitForSeconds(0.5f);
        effectPooling[tempPoolingIndex].SetActive(false);
        Debug.Log("pooling");
    }
}
