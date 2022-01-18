using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopPanelController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject smallBoard1;
    [SerializeField] GameObject smallBoard2;
    [SerializeField] GameObject player;
    [SerializeField] GameObject Panel;
    [SerializeField] TextMeshProUGUI moneyText;
    void CloseShop()
    {
        gameObject.SetActive(false);
    }
    void CloseSmallBoard1()
    {
        smallBoard1.gameObject.SetActive(false);
    }
    void CloseSmallBoard2()
    {
        smallBoard2.gameObject.SetActive(false);
    }

    void BuySword0()
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

    void BuySword1()
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
    void BuySword2()
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
    void BuySword3()
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
