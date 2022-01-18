using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTrapController : MonoBehaviour
{
    GameObject spearTrap;
    Vector3 originPos;
    bool isUpState = true;
    [SerializeField]
    float posY;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        spearTrap = transform.GetChild(0).gameObject;
        originPos = spearTrap.transform.position;
        animator = GetComponent<Animator>();
        StartCoroutine(StartTrap());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(animator.GetBool("isUp"));
        if(isUpState)
        {
            //spearTrap.transform.position += new Vector3(0, posY, 0);
            if (!animator.GetBool("isUp"))
            {
                animator.SetBool("isUp", isUpState);
            }
            else
            {
                return;
            }
        }
        else
        {
            animator.SetBool("isUp", isUpState);
            //spearTrap.transform.position -= new Vector3(0, posY, 0);
        }
    }
    

    IEnumerator StartTrap()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            isUpState = !isUpState;
        }
    }
}
