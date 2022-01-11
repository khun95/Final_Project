using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefectedNotification : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player In");
            transform.parent.GetComponent<Monster>().dangerNotificationEvent(other.transform);
        }
    }

}
