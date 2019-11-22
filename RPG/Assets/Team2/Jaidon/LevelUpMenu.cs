using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{
    public GameObject player;
    Stats stats;

    public static bool isPausedForLevelUp = false;

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
    int pointsLeft;

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
        gameObject.SetActive(true);

        numberPointsToSpend = stats.GetStatPointsToSpend();
        pointsLeft = numberPointsToSpend;

        strengthText.text = stats.GetBaseStrength().ToString();
        intelligenceText.text = stats.GetBaseIntelligence().ToString();
        constitutionText.text = stats.GetBaseConstitution().ToString();
        dexterityText.text = stats.GetBaseDexterity().ToString();
        wisdomText.text = stats.GetBaseWisdom().ToString();
    }

    public void AddStrengthButton()
    {
        if (numberPointsToSpend > 0)
        {
            pointsLeft--;
            addIntelligence.gameObject.SetActive(true);
            pointsToSpend.text = pointsLeft.ToString();
        }
    }
    public void AddIntelligenceButton()
    {
        if (numberPointsToSpend > 0)
        {
            pointsLeft--;
            addIntelligence.gameObject.SetActive(true);
            pointsToSpend.text = pointsLeft.ToString();
        }
    }
    public void AddConstitutionButton()
    {
        if (numberPointsToSpend > 0)
        {
            pointsLeft--;
            addConstitution.gameObject.SetActive(true);
            pointsToSpend.text = pointsLeft.ToString();
        }
    }
    public void AddDexterityButton()
    {
        if (numberPointsToSpend > 0)
        {
            pointsLeft--;
            addDexterity.gameObject.SetActive(true);
            pointsToSpend.text = pointsLeft.ToString();
        }
    }
    public void AddWisdomButton()
    {
        if (numberPointsToSpend > 0)
        {
            pointsLeft--;
            addWisdom.gameObject.SetActive(true);
            pointsToSpend.text = pointsLeft.ToString();
        }
    }

    public void ResetButton()
    {
        pointsLeft = numberPointsToSpend;   // Reset to grabbed value
        pointsToSpend.text = pointsLeft.ToString();

        addStrength.gameObject.SetActive(false);
        addIntelligence.gameObject.SetActive(false);
        addConstitution.gameObject.SetActive(false);
        addDexterity.gameObject.SetActive(false);
        addWisdom.gameObject.SetActive(false);
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
        gameObject.SetActive(false);
    }
}