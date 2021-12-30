using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform charactorBody;
    [SerializeField] Transform cameraArm;
    [SerializeField] float moveSpeed;
    Animator animator;
    public static bool isLoaded;
    //private void Awake()
    //{
    //    if (FindObjectsOfType<PlayerController>().Length != 1)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    void Start()
    {
        animator = charactorBody.GetComponent<Animator>();
    }
    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        animator.SetBool("isWalk", isMove);
        if (isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            charactorBody.forward = lookForward;
            transform.position += moveDir * Time.deltaTime * moveSpeed;
        }
        //Debug.DrawRay(cameraArm.position, cameraArm.forward, Color.red);
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            animator.Play("Slash2");
        }
    }
}
