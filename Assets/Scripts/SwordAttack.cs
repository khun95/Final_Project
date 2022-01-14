using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SwordAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int poolingIndex = 0;
    [SerializeField] int poolingNum = 0;
    [SerializeField] List<GameObject> effectPooling;
    [SerializeField] GameObject effectPos;
    [SerializeField] GameObject effect;
    [SerializeField] GameObject effectFactory;
    [SerializeField] GameObject enchant;
    [SerializeField] TextMeshProUGUI monsterName;
    public Slider mainHpBar;
    public Slider BossBerserkeBar;
    public Image imageSkill;
    GameObject monster;
    public bool isDead = true;
    public bool isEnchant;
    public float berserkTime;
    public float maxBerserkTime;
    public static int swordAtt = 10;
    private void Awake()
    {
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
        maxBerserkTime = berserkTime;
        mainHpBar.gameObject.SetActive(false);
        StartCoroutine(CoolTime(3f,3f));
    }
    private void OnEnable()
    {
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
            if (isDead)
            {
                monster = other.gameObject;
                mainHpBar.gameObject.SetActive(true);;
                monsterName.text = monster.gameObject.name;
                isDead = false;
            }
            if (!other.GetComponent<Monster>().isHit)
            {
                effectPooling[poolingIndex].SetActive(true);
                effectPooling[poolingIndex].gameObject.transform.position = effectPos.gameObject.transform.position;
                StartCoroutine(EffectsObjectPooling(poolingIndex));
                poolingIndex++;
                
            }
        }
        else if(other.tag == "Boss")
        {
            if (isDead)
            {
                monster = other.gameObject;
                BossBerserkeBar.gameObject.SetActive(true);
                mainHpBar.gameObject.SetActive(true);
                monsterName.text = monster.gameObject.name;
                Debug.Log(monster.name);
                isDead = false;
            }
            if (!other.GetComponent<Monster>().isHit)
            {
                effectPooling[poolingIndex].SetActive(true);
                effectPooling[poolingIndex].gameObject.transform.position = effectPos.gameObject.transform.position;
                StartCoroutine(EffectsObjectPooling(poolingIndex));
                poolingIndex++;

            }
        }
    }
    IEnumerator CoolTime(float currentCool, float maxCool)
    {
        Debug.Log("cooltime");
        while(true)
        {
            if (isEnchant)
            {
                if (currentCool < 0)
                    currentCool = maxCool;
                currentCool -= Time.deltaTime;
                imageSkill.fillAmount = currentCool / maxCool;
                yield return new WaitForFixedUpdate();
            }
            else
            {
                imageSkill.fillAmount = 1;
                yield return new WaitForFixedUpdate();
            }
        }
        Debug.Log("cooltime End");
    }

    // Update is called once per frame
    void Update()
    {
        if (poolingIndex >= poolingNum)
            poolingIndex = 0;
        if (isEnchant)
        {
            swordAtt = 20;
        }
        else
        {
            swordAtt = 10;
        }
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
                //StartCoroutine(CoolTime(3f));
            }
            
        }

        if(monster != null)
        {
            if (monster.GetComponent<Monster>().isEnter == false)
            {
                Debug.Log("off");
                isDead = true;
                mainHpBar.gameObject.SetActive(false);
            }
            if (monster.GetComponent<Monster>().hp <= 0)
            {
                isDead = true;
                mainHpBar.gameObject.SetActive(false);
            }
            else
            {
                mainHpBar.value = monster.GetComponent<Monster>().hpBar.value;
            }
        }

    }

    IEnumerator EffectsObjectPooling(int tempPoolingIndex)
    {
        Debug.Log(effectPooling[tempPoolingIndex].name);
        yield return new WaitForSeconds(0.5f);
        effectPooling[tempPoolingIndex].SetActive(false);
    }
    IEnumerator BerserkeTimeDescrease()
    {
        while (berserkTime >= 0)
        {
            yield return new WaitForSeconds(1f);
            berserkTime--;
        }
    }
}
