using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Transform playerPos;
    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gameObject.transform.LookAt(playerPos);
        dir = playerPos.position - transform.position;
        GetComponent<Rigidbody>().AddForce(dir * Time.deltaTime * 10000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
