using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.1f;

    void Update()
    {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}