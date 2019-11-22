using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObj : MonoBehaviour
{
    public bool persistentObject = false;
    public Collider mCollider;
    public abstract void Interact(KeyCode input);
    public abstract void OnTouch(GameObject obj);
    public abstract void IsTouching(GameObject obj);
    public abstract void OnExit(GameObject obj);
    public abstract void ObjUpdate();
    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
        return;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Collider GetCollider() { return mCollider; }
    // Start is called before the first frame update
    void Start()
    {
        mCollider = GetComponent<Collider>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        ObjUpdate();
    }
    private void OnCollisionEnter(Collision collision)
    {
        OnTouch(collision.gameObject);
    }
    private void OnCollisionStay(Collision collision)
    {
        IsTouching(collision.gameObject);
    }
    public void OnCollisionExit(Collision collision)
    {
        OnExit(collision.gameObject);
    }


}
