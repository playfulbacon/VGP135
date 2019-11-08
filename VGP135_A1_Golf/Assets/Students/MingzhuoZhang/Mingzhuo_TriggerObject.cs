using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Mingzhuo_TriggerObject : MonoBehaviour
{
    public bool mIsOn = false;

    public Color mOnColor;
    private Color mRegularColor;
    private Renderer mRenderr;
    void Awake()
    {
        mRenderr = gameObject.GetComponent<Renderer>();
        gameObject.GetComponent<Collider>().isTrigger = true;
        mRegularColor = mRenderr.material.color;
    }

    public void OnTriggerEnter(Collider other)
    {
        var rb = other.gameObject.GetComponentInParent<Rigidbody>();
        if (rb)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(0.0f, 5.0f, 0.0f),ForceMode.Impulse);
        }
        mRenderr.material.color = mOnColor;
        mIsOn = true;
    }

    public void OnTriggerExit(Collider other)
    {
        mRenderr.material.color = mRegularColor;
        mIsOn = false;
    }
}
