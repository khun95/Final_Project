using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerController : MonoBehaviour
{
    [SerializeField] GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            boss.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
