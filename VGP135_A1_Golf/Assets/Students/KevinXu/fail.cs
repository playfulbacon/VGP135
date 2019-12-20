using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fail : MonoBehaviour
{
    public GameObject failMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public virtual void OnGround()
    {
        Debug.Log("onground");
        failMenu.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        OnGround();
    }


}
