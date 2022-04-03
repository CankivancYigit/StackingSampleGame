using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public List<GameObject> characters = new List<GameObject>();
    
    [SerializeField] private float stackGap;
    [SerializeField] private float objectStackAnimDelay = 0.2f;
    [SerializeField] private float horizontalMoveDelay = 0.1f;
    
    private Vector3 objectScale;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
       objectScale  = characters[0].transform.localScale;
    }

    private void Update()
    {
        HorizontalMoveObjectsWithDelay();
    }

    public void StackObjects(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = characters[index].transform.localPosition;
        Quaternion newRotation = characters[index].transform.localRotation;
        newPos.z += stackGap;
        other.transform.localPosition = newPos;
        other.transform.localRotation = newRotation;
        StartCoroutine(ObjectStackingAnim());
    }

    public IEnumerator ObjectStackingAnim()
    {
        for (int i = characters.Count - 1; i >= 0; i--)
        {
            Vector3 animObjectScale = objectScale * 1.5f;

            characters[i].transform.DOScale(animObjectScale, 0.1f);
                yield return new WaitForSeconds(objectStackAnimDelay);
                characters[i].transform.DOScale(objectScale, 0.1f);
        }
    }

    public void HorizontalMoveObjectsWithDelay()
    {
        for (int i = 1; i < characters.Count; i++)
        {
            Vector3 pos = characters[i].transform.position;
            pos.x = characters[i - 1].transform.position.x;
            characters[i].transform.DOMoveX(pos.x, horizontalMoveDelay);
        }
    }
}
