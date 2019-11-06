using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    Rigidbody rb;
    bool isPressed = false;
    bool isDragging = false;
    public Transform aimPrefab;
    Vector3 hitDirection;
    float hitForce = 1000f;
    float maxHealth = 100.0f;
    public float health = 0.0f;
    public Slider slider;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aimPrefab = Instantiate(aimPrefab);
        aimPrefab.gameObject.SetActive(false);
        health = maxHealth;
    }

    void Update()
    {
        UpdateUI();

        if (Input.GetMouseButtonDown(0))
        {
            rb.isKinematic = true;
            isPressed = true;
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
                    isDragging = true;
                    aimPrefab.gameObject.SetActive(true);

                    hitDirection = -(groundHit - transform.position).normalized;
                    aimPrefab.transform.forward = hitDirection;
                    aimPrefab.position = transform.position + hitDirection * 1.25f;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            rb.isKinematic = false;
            isPressed = false;
            aimPrefab.gameObject.SetActive(false);

            if (isDragging)
                rb.AddForce(hitDirection * hitForce);

            isDragging = false;
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
    }

    public void OnTriggerExit(Collider other)
    {
        FakeGoal fakegoal = other.attachedRigidbody?.GetComponent<FakeGoal>();
        if(fakegoal)
        {
            fakegoal.SetTextInactive();
        }
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }
    public void UpdateUI()
    {
        slider.value = CalculateHealth();
        if(health <= 0.0f)
        {
            //Reset level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //Destroy(gameObject)
        }
        if (health >= maxHealth)
        {
            slider.value = maxHealth;
            health = maxHealth;
        }
    }
}
