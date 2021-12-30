using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    Rigidbody rigid;
    Camera camera;
    [SerializeField] private float speed;
    [SerializeField]
    private GameObject charactor;
    Animator animator;
    bool isMove;
    public static bool isLoaded;
    // Start is called before the first frame update

    private void Awake()
    {
        if(FindObjectsOfType<Players>().Length != 1)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        camera = transform.GetChild(0).GetComponent<Camera>();
        animator = charactor.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        rigid.Move(gameObject, speed, ref isMove);
        //Debug.Log(isMove);
        if (isMove)
        {
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }
        rigid.PlayerRotation(gameObject, 2f);
        camera.CameraRotation(2f);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           
            animator.Play("Slash2");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isSlash1", true);
        }
    }
}
