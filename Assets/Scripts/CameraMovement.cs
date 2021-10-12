using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Transform playerT;

    [SerializeField]
    float deadZone;

    [SerializeField]
    float trackingSpeed;


    float distance;
    Transform cameraT;
    bool tracking = true;
    Vector3 newPos;

    void Awake()
    {
        cameraT = GetComponent<Transform>();
    }

    void Update()
    {
        distance = ((Vector2)cameraT.position - (Vector2)playerT.position).magnitude;
        Debug.Log(tracking);
    }

    void FixedUpdate()
    {
        if (!tracking && distance > deadZone)
        {
            tracking = true;
        }
        if (tracking)
        {
            newPos = (cameraT.position + (playerT.position - cameraT.position) * trackingSpeed / 60);
            newPos.z = cameraT.position.z;
            cameraT.position = newPos;
            if (distance < 0.1)
            {
                tracking = false;
            }
        }
    }
}
