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
        currCoins += coins;

        ShowCoins();
    }

    private void ShowCoins()
    {
        showCoinsTMP.text = currCoins.ToString();
    }
}