using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public virtual void OnGround()
    {
        FindObjectOfType<FailMenu>().SetFailMenu(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        OnGround();
    }


}
