using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public int att = 10;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
