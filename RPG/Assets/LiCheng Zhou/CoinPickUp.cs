using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public GameObject coin;
    

    private void OnTriggerEnter(Collider collision)
    {
        Destroy(coin);
        FindObjectOfType<CoinsCounter>().SetScore();
    }
}
