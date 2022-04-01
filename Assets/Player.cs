using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public List<GameObject> characters = new List<GameObject>();
    
    [SerializeField] private float stackGap;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void StackObjects(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = characters[index].transform.localPosition;
        Quaternion newRotation = characters[index].transform.localRotation;
        newPos.z += stackGap;
        other.transform.localPosition = newPos;
        other.transform.localRotation = newRotation;
    }
}
