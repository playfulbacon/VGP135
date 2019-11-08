using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWaysMovement : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed;
    public Transform currentFolloPoint;
    public float customDeltaTime;
    // Start is called before the first frame update
    void Start()
    {
        if (endPoint)
            currentFolloPoint = endPoint;

        if (startPoint)
            currentFolloPoint = startPoint;
    }

    // Update is called once per frame
    void Update()
    {
        float step = 0.0f;
        if (Time.timeScale > 0.0)
            step = speed * Time.unscaledDeltaTime; // calculate distance to move

        Debug.Log("Moving Platform Move towards start point");
        transform.position = Vector3.MoveTowards(transform.position, currentFolloPoint.position, step);

        //Creating range when objects is close to end point
        if (transform.position.x < endPoint.position.x + 0.8f &&
            transform.position.x > endPoint.position.x - 0.8f)
        {
            Debug.Log("Moving Platform  Move towards start point");
            currentFolloPoint = startPoint;
        }
            
        //Creating range when objects is close to end point
        if (transform.position.x < startPoint.position.x + 0.8f &&
            transform.position.x > startPoint.position.x - 0.8f)
        {
            Debug.Log("Moving Platform Move towards end point");
            currentFolloPoint = endPoint;
        }
    }
}
