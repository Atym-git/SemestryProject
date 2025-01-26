using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountNShowExp : MonoBehaviour
{
    private float amountOfExp;

    private float expToLvlUP;

    [field: SerializeField, HideInInspector] private TextMeshProUGUI showExpTMP;

    public void AddExp(float exp)
    {
        amountOfExp += exp;
        if (amountOfExp >= expToLvlUP)
        {
            amountOfExp -= expToLvlUP;
        }
        ShowExp();
    }

    private void ShowExp()
    {
        showExpTMP.text = amountOfExp.ToString();
    }
}