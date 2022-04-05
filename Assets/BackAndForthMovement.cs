using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForthMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float xOffset, zOffset;
        
    [SerializeField] private float waitingTime = 0.5f;
        
    private Vector3 startingPos;
    private Vector3 targetPos;
    private Vector3 nextPosition;

    private Vector3 directionToFace;
    private float currentSpeed;
        
    // Use this for initialization
    void Start()
    {
        startingPos = new Vector3(transform.position.x , transform.position.y, transform.position.z);
        targetPos = new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z + zOffset);
        nextPosition = targetPos;
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, nextPosition, currentSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position,startingPos) < 0.1f)
        {
            StartCoroutine(WaitForTurn(targetPos));
        }

        if (Vector3.Distance(transform.position,targetPos) < 0.1f)
        {
            StartCoroutine(WaitForTurn(startingPos));

        }
    }

    private IEnumerator WaitForTurn(Vector3 target)
    {
        currentSpeed = 0;
        yield return new WaitForSeconds(waitingTime);
        nextPosition = target;
        currentSpeed = speed;
    }
}

