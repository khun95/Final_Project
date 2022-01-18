using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopPanelController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject smallBoard1;
    public GameObject smallBoard2;
    public GameObject player;
    public GameObject Panel;
    public TextMeshProUGUI moneyText;
    public void CloseShop()
    {
        gameObject.SetActive(false);
    }
    public void CloseSmallBoard1()
    {
        smallBoard1.gameObject.SetActive(false);
    }
    public void CloseSmallBoard2()
    {
        smallBoard2.gameObject.SetActive(false);
    }

    public void BuySword0()
    {
        if(Charactor.money > 100)
        {
            Charactor.currentSwordNum = 0;
            Charactor.money -= 100;
            player.GetComponent<PlayerController>().ChangeSwords();
            smallBoard1.SetActive(true);
        }
        else
        {
            smallBoard2.SetActive(true);
        }
    }

    public void BuySword1()
    {
        if (Charactor.money > 100)
        {
            Charactor.currentSwordNum = 1;
            Charactor.money -= 100;
            player.GetComponent<PlayerController>().ChangeSwords();
            smallBoard1.SetActive(true);

        }
        else
        {
            smallBoard2.SetActive(true);
        }
    }
    public void BuySword2()
    {
        if (Charactor.money > 100)
        {
            Charactor.currentSwordNum = 2;
            Charactor.money -= 100;
            player.GetComponent<PlayerController>().ChangeSwords();
            smallBoard1.SetActive(true);
        }
        else
        {
            smallBoard2.SetActive(true);
        }
    }
    public void BuySword3()
    {
        if (Charactor.money > 100)
        {
            Charactor.currentSwordNum = 3;
            Charactor.money -= 100;
            player.GetComponent<PlayerController>().ChangeSwords();
            smallBoard1.SetActive(true);
        }
        else
        {
            smallBoard2.SetActive(true);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        moneyText.text = "CurrentMoney : " + Charactor.money;
    }
}
