using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform objectToFollow;
    [SerializeField] float followSpeed = 10f;
    [SerializeField] float sensitivity = 100f;
    [SerializeField] float clampAngle = 70f;

    float rotX;
    float rotY;

    [SerializeField] Transform mainCamera;
    [SerializeField] Vector3 dirNormalized;
    [SerializeField] Vector3 finalDir;
    [SerializeField] float minDistance;
    [SerializeField] float maxDistance;
    [SerializeField] float finalDistance;
    [SerializeField] float smooth = 10f;

    void Start()
    {
        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;

        dirNormalized = mainCamera.localPosition.normalized;
        finalDistance = mainCamera.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        rotX += -(Input.GetAxis("Mouse Y")) * sensitivity * Time.deltaTime;
        rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
        transform.rotation = rot;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position, followSpeed * Time.deltaTime);

        finalDir = transform.TransformPoint(dirNormalized * maxDistance);

        RaycastHit hit;

        if(Physics.Linecast(transform.position, finalDir, out hit))
        {
            finalDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            finalDistance = maxDistance;
        }
        mainCamera.localPosition = Vector3.Lerp(mainCamera.localPosition, dirNormalized * finalDistance, Time.deltaTime * smooth);
    }
}
