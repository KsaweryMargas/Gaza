using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingStarController : MonoBehaviour
{
    public float rotationSpeed = 500f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
