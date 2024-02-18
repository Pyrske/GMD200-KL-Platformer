using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : BaseMovingPlatform
{
    [SerializeField] private float rotateSpeed = 1f;
    [SerializeField] private float radius = 1f;

    void Update()
    {
        float angle = Time.time * rotateSpeed / 180f * Mathf.PI;
        while (angle > 2f * Mathf.PI)
        {
            angle -= 2f * Mathf.PI;
        }
        transform.localPosition = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        SetDirection(2f * angle > 3f * Mathf.PI || 2f * angle < Mathf.PI);
    }
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.DrawWireDisc(transform.parent.position, Vector3.back, radius);
    }
}
