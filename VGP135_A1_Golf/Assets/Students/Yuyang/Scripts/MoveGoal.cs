using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGoal : MonoBehaviour
{
    // Start is called before the first frame update

    public int awarenessRadius = 5;
    public bool isAwared = false;
    public float speed = -1.0f;
    public GameObject player;
    bool isActive = true;
    void Start()
    {
     
    }

    // Update is called once per frame
    public virtual void OnHit()
    {
        isActive = false;
        Debug.Log("1");
        FindObjectOfType<GoalMenu>().SetGoalMenu(true);
    }

    void Update()
    {
        if (player != null && (isActive))
        {
            // Awareness
            isAwared = Vector3.Magnitude(transform.position - player.transform.position) < awarenessRadius;
            if (isAwared)
            {
                Vector3 lookAt = (player.transform.position - transform.position);
                lookAt.y = 0.0f;

                // If player is in range will move towards them

                    // Apply force
                   
                    transform.position = (transform.position + lookAt * speed);
                if (speed < 0)
                {
                    speed += 0.05f;
                }
               
                // If in range will attack

                lookAt = transform.forward + lookAt * 0.1f;
                transform.forward = Vector3.Normalize(lookAt);
            }
        }
    }


}
