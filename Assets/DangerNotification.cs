using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerNotification : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
        {
                //StartCoroutine(other.GetComponent<Monster>().FindPlayer());
        }
    }
}
