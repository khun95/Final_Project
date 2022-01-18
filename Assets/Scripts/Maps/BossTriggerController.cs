using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerController : MonoBehaviour
{
    [SerializeField] GameObject boss;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            boss.gameObject.SetActive(true);
        }
    }

}
