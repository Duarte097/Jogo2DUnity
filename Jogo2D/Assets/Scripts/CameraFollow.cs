using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 1f;

    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 startPosition = new Vector3(target.position.x, target.position.y, -1);
            Vector3 smoothPosition = Vector3.Lerp(transform.position, startPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothPosition;
        }
    }
}
