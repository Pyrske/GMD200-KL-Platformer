using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform followObject;
    void FixedUpdate()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, followObject.position, 0.6f);
        newPosition.z = -10f;
        transform.position = newPosition;
    }
}
