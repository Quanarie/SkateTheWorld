using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform skater;

    void FixedUpdate()
    {
        Vector3 pos = Vector2.Lerp(transform.position, skater.position, 0.1f);
        pos.z = transform.position.z;
        transform.position = pos;
    }
}
