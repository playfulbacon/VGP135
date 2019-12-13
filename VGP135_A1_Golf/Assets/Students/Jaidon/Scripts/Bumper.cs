using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]// Allows switchable bumper in editor
public class Bumper : MonoBehaviour
{
    public enum BumperType
    {
        Circle,
        Flat
    };

    public BumperType bumperType = BumperType.Circle;

    public GameObject BumperCircle;
    public GameObject BumperFlat;

    private void Awake()
    {
        SetBumper();
    }

    private void OnValidate()
    {
        SetBumper();
    }

    void SetBumper()
    {
        if (bumperType == BumperType.Circle)
        {
            BumperFlat.SetActive(false);
            BumperCircle.SetActive(true);
        }
        else if (bumperType == BumperType.Flat)
        {
            BumperCircle.SetActive(false);
            BumperFlat.SetActive(true);
        }
    }
}