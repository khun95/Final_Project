using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public int coinValue;
    public Transform coinPos;
    // Start is called before the first frame update
    void OnEnable()
    {
        gameObject.transform.SetParent(null, false);
        gameObject.transform.position = coinPos.transform.position;      
        CoinSetting();
    }
    public void CoinSetting()
    {
        Rigidbody rigid = GetComponent<Rigidbody>();
        //  transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0f);
        rigid.velocity = Vector3.up * 5;
        rigid.AddForce(transform.forward * 100);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log(coinValue);
            Charactor.money += coinValue;
            gameObject.SetActive(false);
        }
    }
}
