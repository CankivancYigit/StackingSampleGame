using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private Vector3 rotationAxis;
    void Update()
    {
        transform.Rotate(rotationSpeed * rotationAxis * Time.deltaTime);
    }
}
