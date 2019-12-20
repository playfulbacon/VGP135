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
    [SerializeField]
    private float rotationSpeed = 20.0f;
    float speedCooldown = 5.0f;
    private NavMeshAgent agent;
    private bool isMoving;
    private Player player;
    private bool speedCooldownBool;
    // - Getter & Setter -----------------------------------------------------------------------
    public bool IsMoving { get { return isMoving; } }
    public NavMeshAgent Agent { get { return agent; } }

    // - MonoBehavior functions ----------------------------------------------------------------
    void Awake()
    {
        // speed = GetComponent<CharacterStatus>().GetMovementSpeed();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        player = GetComponent<Player>();
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
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("right click pressed");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 mousePos = hit.point;
                transform.position = new Vector3(mousePos.x, mousePos.y, mousePos.z);
                agent.destination = mousePos;
                Debug.LogWarning("moved player");
            }
            player.TeleportAttack();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        { 

            StartHaste();
        }

        if (speedCooldownBool)
        {
            speedCooldown -= Time.deltaTime;
        }

        if (speedCooldown <= 0)
        {
            agent.speed = speed;
            speedCooldownBool = false;
            speedCooldown = 5.0f;
        }



        isMoving = Vector3.SqrMagnitude(agent.velocity) > 1.0f;
    }

    public void StartHaste()
    {
        if (!speedCooldownBool)
        {
        agent.speed += 5.0f;
            speedCooldownBool = true;
        }
    }

    public void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.25f);
    }
}
