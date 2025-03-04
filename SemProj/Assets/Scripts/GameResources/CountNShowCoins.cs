using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountNShowCoins : MonoBehaviour
{
    [field: SerializeField, HideInInspector] private TextMeshProUGUI showCoinsTMP;

    private int currCoins = 0;

    private float polluteMultiplier = 1;

    private void Start()
    {
        showCoinsTMP.text = currCoins.ToString();
    }

    public void AddCoins(float coins)
    {
        currCoins += (int)(coins * polluteMultiplier);
        Debug.Log(polluteMultiplier);
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

    public void PolluteMultiplier(float PolluteMultiplier)
    {
        polluteMultiplier = PolluteMultiplier;
    }

    public int SaveCoins() => currCoins;

    private void ShowCoins()
    {
        showCoinsTMP.text = currCoins.ToString();
    }
}