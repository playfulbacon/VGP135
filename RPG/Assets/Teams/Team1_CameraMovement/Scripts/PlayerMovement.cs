using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Required Function from other team
// [Character Status] GetMovementSpeed()

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    private NavMeshAgent agent;
    private bool isMoving;

    // - Getter & Setter -----------------------------------------------------------------------
    public bool IsMoving{ get { return isMoving; }}

    // - MonoBehavior functions ----------------------------------------------------------------
    void Awake()
    {
        // speed = GetComponent<CharacterStatus>().GetMovementSpeed();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 groundHit = hit.point;
                agent.destination = groundHit;
            }
        }

        isMoving = Vector3.SqrMagnitude(agent.velocity) > 1.0f;
    }
}
