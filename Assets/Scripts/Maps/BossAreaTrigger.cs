using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAreaTrigger : MonoBehaviour
{
    [SerializeField] GameObject doors;
    [SerializeField] GameObject player;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject newHeadPos;
    Animator animator;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Head");
        newHeadPos = GameObject.FindGameObjectWithTag("Head2");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        animator = doors.GetComponent<Animator>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            doors.GetComponent<DoorObjectController>().enabled = false;
            animator.SetBool("isOpen", false);
            player.transform.position = newHeadPos.transform.position;
        }
    }
}
