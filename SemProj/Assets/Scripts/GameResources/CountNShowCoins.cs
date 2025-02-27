using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountNShowCoins : MonoBehaviour
{
    [field: SerializeField, HideInInspector] private TextMeshProUGUI showCoinsTMP;

    [HideInInspector] public float currCoins = 0;

    private void Start()
    {
        showCoinsTMP.text = currCoins.ToString();
    }

    public void AddCoins(float coins)
    {
        currCoins += (int)coins;

        ShowCoins();
    }

    public bool IsEnoughToBuy(float coins)
    {
        if (currCoins < coins)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void ShowCoins()
    {
        showCoinsTMP.text = currCoins.ToString();
    }
}