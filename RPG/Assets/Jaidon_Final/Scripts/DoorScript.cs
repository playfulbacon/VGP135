using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool keyIsUnique = false;    // If true, only accepts keys with a key ID of the same value
    public bool isLocked = true;

    public int keyValue = -1;           // If you want a unique key you have to make sure they are the same (keyValue is a part of KeyScript as well)

    Vector3 lockedPosition;
    Vector3 open;
    public Vector3 openPosition;

    float percentMove = 0.0f;
    bool isMoving = false;

    public void Awake()
    {
        lockedPosition = transform.position;
        open = lockedPosition + openPosition;
    }

    public void OpenDoor(int keyVal = -1)
    {
        if (isLocked)
        {
            if (keyIsUnique)
            {
                // Only open door if player has correct key
                if (keyVal == keyValue)
                {
                    isLocked = false;
                    isMoving = true;
                }
                else
                {
                    Debug.Log("Attempted to unlock door " + gameObject.name + " but missing KeyID: " + keyValue);
                }
            }
            // Key doesn't matter, only having a key matters
            else
            {
                isLocked = false;
                isMoving = true;
            }
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            percentMove += Time.deltaTime;
            if (percentMove >= 1.0f)
            {
                isMoving = false;
                transform.position = open;
            }

            transform.position = Vector3.Lerp(lockedPosition, open, percentMove);
        }
    }
}