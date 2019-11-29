using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject ranger;
    public GameObject wizard;

    private void Awake()
    {
        ranger.SetActive(true);
        wizard.SetActive(false);
    }

    public void AcceptButton()
    {

    }

    public void NextButton()
    {
        Debug.Log("Next");
        if (ranger.activeInHierarchy)
        {
            ranger.SetActive(false);
            wizard.SetActive(true);
        }
        else
        {
            ranger.SetActive(true);
            wizard.SetActive(false);
        }
    }

    public void PreviousButton()
    {
        Debug.Log("Previous");
        if (wizard.activeInHierarchy)
        {
            ranger.SetActive(true);
            wizard.SetActive(false);
        }
        else
        {
            ranger.SetActive(false);
            wizard.SetActive(true);
        }
    }
}