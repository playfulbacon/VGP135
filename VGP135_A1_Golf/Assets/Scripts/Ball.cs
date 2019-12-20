using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    Rigidbody rb;
    bool isPressed = false;
    bool isDragging = false;
    public Transform aimPrefab;
    Vector3 hitDirection;
    float hitMaxForce = 1000f;

    [SerializeField]
    float currentForce = 0f;

    Vector3 mouseStartPosition;
    Vector3 mouseFinalPosition;

    float forcePercentage = 0.0f;

    float maxForceDistance = 200.0f;

    float timeRatio = 0.2f;

    float currentForceDistance;

    float aimPrefabZLength;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aimPrefab = Instantiate(aimPrefab);
        aimPrefabZLength = aimPrefab.transform.localScale.z;
        aimPrefab.gameObject.SetActive(false);
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.isKinematic = true;
            isPressed = true;

            Time.timeScale = timeRatio;
        }

        if (isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 groundHit = hit.point;
                groundHit.y = transform.position.y;

                if (Vector3.Distance(transform.position, groundHit) > 0.5f)
                {
                    if (!isDragging)
                        mouseStartPosition = Input.mousePosition;

                    isDragging = true;
 
                    aimPrefab.gameObject.SetActive(true);

                    hitDirection = -(groundHit - transform.position).normalized;
                    aimPrefab.transform.forward = hitDirection;
                    aimPrefab.position = transform.position - hitDirection * 0.5f;
                }
            }
        }

        if (isDragging)
        {
            mouseFinalPosition = Input.mousePosition;
            currentForceDistance = (mouseFinalPosition - mouseStartPosition).magnitude;

            forcePercentage = currentForceDistance / maxForceDistance;

            if (forcePercentage > 1.0f)
                forcePercentage = 1.0f;

            aimPrefab.GetComponent<Aimer>().forceQuad.transform.localScale = new Vector3(aimPrefab.localScale.x, aimPrefab.localScale.y, -(aimPrefabZLength * forcePercentage));
            //aimPrefab.localScale = new Vector3(aimPrefab.localScale.x, aimPrefab.localScale.y, -(aimPrefabZLength * forcePercentage));
        }

        if (Input.GetMouseButtonUp(0))
        {
            currentForce = hitMaxForce * forcePercentage;

            rb.isKinematic = false;
            isPressed = false;
            aimPrefab.gameObject.SetActive(false);

            if (isDragging)
                rb.AddForce(hitDirection * currentForce);

            isDragging = false;
            currentForce = 0.0f;

            Time.timeScale = 1.0f;
        }

        Time.fixedDeltaTime = .02f * Time.timeScale;
        //Debug.Log(Time.timeScale);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // When ball trigger the trap, resize it.
        if  (collision.gameObject.CompareTag("Trap"))
        {
            Traps trap = collision.gameObject.GetComponent<Traps>();
            bool randomTrap = Random.Range(0, 10) < 5;
            if (randomTrap)
            {
                StartCoroutine(trap.ScaleUp(gameObject));
            }
            else
            {
                StartCoroutine(trap.Shrinking(gameObject));
            }
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Goal goal = other.attachedRigidbody?.GetComponent<Goal>();
        if (goal)
        {
            goal.OnHit();
            rb.isKinematic = true;
        }

        Collectable collectable = other.attachedRigidbody?.GetComponent<Collectable>();
        if (collectable)
        {
            collectable.OnCollect();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        FakeGoal fakegoal = other.attachedRigidbody?.GetComponent<FakeGoal>();
        if(fakegoal)
        {
            fakegoal.SetTextInactive();
        }
    }
}
