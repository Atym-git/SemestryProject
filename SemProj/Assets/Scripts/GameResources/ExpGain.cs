using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LevelUp))]
public class ExpGain : MonoBehaviour
{
    [HideInInspector] public float currExp { get; private set; }
    [SerializeField] private float expToLevelUp;

    [field: SerializeField, HideInInspector] private Image expSlider;

    [SerializeField] private LevelUp levelScript;

    [SerializeField] private float lvlUpMultiplier = 1.25f;

    private float polluteMultiplier = 1;

    private void Start()
    {
        levelScript.gameObject.GetComponent<LevelUp>();
    }

    public void GainExp(float exp)
    {
        currExp += exp * polluteMultiplier;
        LevelUp();
        ShowSliderValue();
    }

    private void ShowSliderValue()
    {
        float sliderValue = currExp / expToLevelUp;
        expSlider.fillAmount = sliderValue;
    }

    private void LevelUp()
    {
        while (currExp >= expToLevelUp)
        {
            currExp -= expToLevelUp;
            expSlider.fillAmount = 0;
            AllignExpNLevel(1);
            levelScript.LevelUpgraded();
        }
    }

    public void AllignExpNLevel(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            expToLevelUp *= lvlUpMultiplier;
        }
    }

    public void PolluteMultiplier(float PolluteMultiplier)
    {
        polluteMultiplier = PolluteMultiplier;
    }

    
}