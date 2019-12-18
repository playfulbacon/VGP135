using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKey : MonoBehaviour
{
    List<int> keyValues = new List<int>();
    public void OnTriggerEnter(Collider collider)
    {
        KeyScript key = collider.GetComponent<KeyScript>();

        if (key)
        {
            keyValues.Add(key.keyValue);
            Destroy(key.gameObject);
            return;
        }

        DoorScript door = collider.attachedRigidbody.GetComponent<DoorScript>();
        if (door)
        {
            if (door.keyIsUnique)
            {
                foreach (int keyVal in keyValues)    // Check list of keys to see if we have the unique one
                {
                    if (keyVal == door.keyValue)
                    {
                        door.OpenDoor(keyVal);
                        keyValues.Remove(keyVal);
                    }
                }
            }
            else
            {
                foreach(int keyVal in keyValues)
                {
                    if (keyVal == -1)
                    {
                        door.OpenDoor();
                        keyValues.Remove(-1);
                    }
                }
            }
        }
    }
}