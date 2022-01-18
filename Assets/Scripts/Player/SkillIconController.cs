using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillIconController : MonoBehaviour
{
    public List<GameObject> skill1Icons;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < skill1Icons.Count; i++)
        {
            if(i == Charactor.currentSwordNum)
            {
                skill1Icons[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
