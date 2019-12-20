using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    public static Ball instance;

    Rigidbody rb;
    bool isPressed = false;
    bool isDragging = false;
    public Transform aimPrefab;
    Vector3 hitDirection;
    float hitForce = 1000f;

    public Text moveCounterText;
    private int moveCounter;
    private int matchTime;

    private void Awake()
    {
        matchTime = 99;
        moveCounter = matchTime;
        moveCounterText.text = moveCounter.ToString();
        instance = GetComponent<Ball>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aimPrefab = Instantiate(aimPrefab);
        aimPrefab.gameObject.SetActive(false);
    }

    void Update()
    {
        if(moveCounter == 0)
        {
            SetGameOver();
            StopAllCoroutines();
        }
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

    public int MoveCounter
    {
        get { return moveCounter; }

        set
        {
            moveCounter = value;
            moveCounterText.text = moveCounter.ToString();
        }
    }
    
    public void SetGameOver()
    {
        GameOver.instance.gameOver = true;
        Time.timeScale = 0.0f;
        GameOver.instance.gameOverHolder.SetActive(true);
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

    private IEnumerable StartCoroutine(int moveCounter)
    {
        moveCounter -= (int)Time.deltaTime;
        if(moveCounter < 0)
        {
            SetGameOver();
        }
        yield return new WaitForSeconds(5.0f);
        StartCoroutine(moveCounter);
    }
}
