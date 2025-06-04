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

    [SerializeField] private GameObject firstGeneratorIncdialog;
    [SerializeField] private Dialogues dialogues;

    private const int _minGeneratorIncome = 3;
    private bool _dialogueOut = false;

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
        DialogueCheck(Mathf.RoundToInt(coins));
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

    private void DialogueCheck(int coins)
    {
        if (coins >= _minGeneratorIncome && !_dialogueOut)
        {
            dialogues.ActivateSingleDialogue(firstGeneratorIncdialog);
            _dialogueOut = true;
        }
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