using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerNotification : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Monster>() != null)
        {
            transform.parent.GetComponent<Monster>().dangerNotificationEvent += other.GetComponent<Monster>().SetDestination;
            Debug.Log(other.transform.name + "In DangerEvent");
        }
           
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Monster>() != null)
        {
            transform.parent.GetComponent<Monster>().dangerNotificationEvent -= other.GetComponent<Monster>().SetDestination;
            Debug.Log(other.transform.name + "Out DangerEvent");
        }
    }
}
