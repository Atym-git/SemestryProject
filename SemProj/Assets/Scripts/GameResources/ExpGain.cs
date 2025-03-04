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
    [HideInInspector] public float currExp;
    [SerializeField] private float expToLevelUp;

    [field: SerializeField, HideInInspector] private Image expSlider;

    [SerializeField, HideInInspector] private LevelUp levelUpScript;

    [SerializeField] private float expMultiplier = 1.25f;

    private float polluteMultiplier;

    private void Start()
    {
        levelUpScript.gameObject.GetComponent<LevelUp>();
    }

    public void OnExpGain(float exp)
    {
        currExp += exp * polluteMultiplier;
        expSlider.fillAmount = currExp / expToLevelUp;
        while (currExp >= expToLevelUp)
        {
            currExp -= expToLevelUp;
            expSlider.fillAmount = 0;
            expToLevelUp *= expMultiplier;
            levelUpScript.LevelUpgraded();
        }
        expSlider.fillAmount = currExp / expToLevelUp;
    }
    public void PolluteMultiplier(float PolluteMultiplier)
    {
        polluteMultiplier = PolluteMultiplier;
    }
}