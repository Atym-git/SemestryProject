using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Level))]
public class ExpGain : MonoBehaviour
{
    [HideInInspector] public float currExp { get; private set; }
    [SerializeField] private float[] expToNextLvlUp;

    [field: SerializeField, HideInInspector] private Image expSlider;

    [SerializeField] private Level levelScript;

    [SerializeField] private float lvlUpMultiplier = 1.25f;

    private float polluteMultiplier = 1;

    private void Awake()
    {
        levelScript.gameObject.GetComponent<Level>();
        levelScript.SetMaxLevel(expToNextLvlUp.Length);
    }

    public void GainExp(float exp)
    {
        currExp += exp * polluteMultiplier;
        LevelUp();
        ShowSliderValue();
    }

    private void ShowSliderValue()
    {
        int currentLevel = levelScript.GetCurrLvl();
        if (currentLevel >= expToNextLvlUp.Length)
        {
            currentLevel = expToNextLvlUp.Length - 1;
        }

        float sliderValue = currExp / expToNextLvlUp[currentLevel];
        expSlider.fillAmount = sliderValue;
    }

    private void LevelUp()
    {
        int currLvl = levelScript.GetCurrLvl();

        if (currLvl >= expToNextLvlUp.Length)
        {
            currLvl = expToNextLvlUp.Length - 1;
        }

        while (currExp >= expToNextLvlUp[currLvl])
        {
            currExp -= expToNextLvlUp[currLvl];
            expSlider.fillAmount = 0;
            //AllignExpNLevel(1);
            levelScript.LevelUpgraded();
        }
    }

    //public void AllignExpNLevel(int amount)
    //{
    //    for (int i = 0; i < amount; i++)
    //    {
    //        expToLevelUp[levelScript.currLevel] *= lvlUpMultiplier;
    //    }
    //}

    public void PolluteMultiplier(float PolluteMultiplier)
    {
        polluteMultiplier = PolluteMultiplier;
    }

    
}