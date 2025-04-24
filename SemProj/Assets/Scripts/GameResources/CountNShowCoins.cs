using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountNShowCoins : MonoBehaviour
{
    [field: SerializeField] private TextMeshProUGUI showCoinsTMP;

    private int currCoins = 0;

    private float polluteMultiplier = 1;

    private void Start()
    {
        showCoinsTMP.text = currCoins.ToString();
    }

    public void AddCoins(float coins)
    {
        if (coins >= 0)
        {
            currCoins += (int)Mathf.Round(coins * polluteMultiplier);
        }
        else
        {
            currCoins += (int)Mathf.Round(coins);
        }
        ShowCoins();
    }

    public bool IsEnoughToBuy(int coins)
    {
        if (currCoins < coins)
        {
            return false;
        }
        //currCoins -= coins;
        return true;
    }

    public void PolluteMultiplier(float PolluteMultiplier)
    {
        polluteMultiplier = PolluteMultiplier;
    }

    public int GetCoins() => currCoins;

    private void ShowCoins()
    {
        showCoinsTMP.text = currCoins.ToString();
    }
}