using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAreaTrigger : MonoBehaviour
{
    public GameObject doors;
    public GameObject player;
    public GameObject mainCamera;
    public GameObject cameraPos;
    public GameObject newHeadPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Head");
        newHeadPos = GameObject.FindGameObjectWithTag("Head2");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            doors.GetComponent<DoorObjectController>().enabled = false;
            player.transform.position = newHeadPos.transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
