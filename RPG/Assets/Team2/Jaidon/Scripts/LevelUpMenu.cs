using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{
    public GameObject player;
    Stats stats;

    public static bool isPausedForLevelUp = false;

    public GameObject levelUpMenuUI;

    public Text strengthText;
    public Text intelligenceText;
    public Text constitutionText;
    public Text dexterityText;
    public Text wisdomText;

    public Text addStrength;
    public Text addIntelligence;
    public Text addConstitution;
    public Text addDexterity;
    public Text addWisdom;

    public Text pointsToSpend;
    int numberPointsToSpend;

    private void Start()
    {
        stats = player.GetComponent<Stats>();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LevelUpMenuActivate();
        }
    }

    public void LevelUpMenuActivate()
    {
        Time.timeScale = 0.0f;
        levelUpMenuUI.SetActive(true);

        numberPointsToSpend = stats.GetStatPointsToSpend() + 1;

        strengthText.text = "Strength: " + stats.GetBaseStrength();
        intelligenceText.text = "Intelligence: " + stats.GetBaseIntelligence();
        constitutionText.text = "Constitution: " + stats.GetBaseConstitution();
        dexterityText.text = "Dexterity: " + stats.GetBaseDexterity();
        wisdomText.text = "Wisdom: " + stats.GetBaseWisdom();
    }

    public void AddStrengthButton()
    {
        if (numberPointsToSpend > 0)
        {
            numberPointsToSpend--;
            addStrength.gameObject.SetActive(true);
            pointsToSpend.text = "Available Points: ";
        }
    }
    public void AddIntelligenceButton()
    {
        if (numberPointsToSpend > 0)
        {
            numberPointsToSpend--;
            addIntelligence.gameObject.SetActive(true);
            pointsToSpend.text = "Available Points: ";
        }
    }
    public void AddConstitutionButton()
    {
        if (numberPointsToSpend > 0)
        {
            numberPointsToSpend--;
            addConstitution.gameObject.SetActive(true);
            pointsToSpend.text = "Available Points: ";
        }
    }
    public void AddDexterityButton()
    {
        if (numberPointsToSpend > 0)
        {
            numberPointsToSpend--;
            addDexterity.gameObject.SetActive(true);
            pointsToSpend.text = "Available Points: ";
        }
    }
    public void AddWisdomButton()
    {
        if (numberPointsToSpend > 0)
        {
            numberPointsToSpend--;
            addWisdom.gameObject.SetActive(true);
            pointsToSpend.text = "Available Points: ";
        }
    }

    public void ResetButton()
    {
        numberPointsToSpend = stats.GetStatPointsToSpend() + 1;
        addStrength.gameObject.SetActive(false);
        addIntelligence.gameObject.SetActive(false);
        addConstitution.gameObject.SetActive(false);
        addDexterity.gameObject.SetActive(false);
        addWisdom.gameObject.SetActive(false);

        pointsToSpend.text = "Available Points: " + numberPointsToSpend;
    }

    public void AcceptButton()
    {
        if (addStrength.IsActive())
        {
            stats.ModifyBaseStrength(1);
            addStrength.gameObject.SetActive(false);
        }
        if (addIntelligence.IsActive())
        {
            stats.ModifyBaseIntelligence(1);
            addIntelligence.gameObject.SetActive(false);
        }
        if (addConstitution.IsActive())
        {
            stats.ModifyBaseConstitution(1);
            addConstitution.gameObject.SetActive(false);
        }
        if (addDexterity.IsActive())
        {
            stats.ModifyBaseDexterity(1);
            addDexterity.gameObject.SetActive(false);
        }
        if (addWisdom.IsActive())
        {
            stats.ModifyBaseWisdom(1);
            addWisdom.gameObject.SetActive(false);
        }

        stats.SetNumberStatPointsToSpend(numberPointsToSpend);

        Time.timeScale = 1.0f;
        levelUpMenuUI.SetActive(false);
    }
}