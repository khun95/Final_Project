using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTest : MonoBehaviour
{
    // Start is called before the first frame update
    int hp = 100;
    bool isHit = false;

    public void HitRelease()
    {
        isHit = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sword")
        {
            if(isHit == false)
            {
                FindObjectOfType<PlayerController>().endAttackAnimeListner += HitRelease;
                hp -= 10;
                isHit = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hp : " + hp);
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
