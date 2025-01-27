using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LevelUp))]
public class ExpGain : MonoBehaviour
{
    [SerializeField] private float currExp;
    [SerializeField] private float expToLevelUp;

    [field: SerializeField, HideInInspector] private Image expSlider;

    [SerializeField, HideInInspector] private LevelUp levelUpScript;

    private void Start()
    {
        levelUpScript.gameObject.GetComponent<LevelUp>();
    }

    public void OnExpGain(float exp)
    {
        currExp += exp;
        expSlider.fillAmount = currExp / expToLevelUp;
        if (currExp >= expToLevelUp)
        {
            currExp -= expToLevelUp;
            expSlider.fillAmount = 0;
            levelUpScript.LevelUpgraded();
        }
    }
}