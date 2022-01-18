using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    void CursorOn()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void CursorOff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Start()
    {
        //CursorOff();
    }
    private void Awake()
    {
        if (FindObjectsOfType<CharactorObjectController>().Length != 1)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.LeftAlt))
        //{
        //    CursorOn();
        //}
        //else
        //{
        //    CursorOff();
        //}
    }
}
