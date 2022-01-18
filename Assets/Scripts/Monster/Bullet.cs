using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform playerPos; 
    Rigidbody rigid;
    Vector2 dir;
    public int att;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        playerPos = GameObject.FindGameObjectWithTag("BulletPoint").GetComponent<Transform>();
        gameObject.transform.LookAt(playerPos);
        //dir = playerPos.position - transform.position;
        //GetComponent<Rigidbody>().AddForce(dir * Time.deltaTime * 10000);
        rigid.velocity = transform.forward * 15;
        StartCoroutine(BulletDestroy());
    }
    IEnumerator BulletDestroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    // Update is called once per frame
}
