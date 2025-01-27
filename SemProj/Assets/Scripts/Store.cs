using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private float upgradeTimeCost;
    [SerializeField] private float upgradeCoinsCost;
    [SerializeField] private float upgradeExpCost;
    [SerializeField] private float upgradeClickerCost;

    [SerializeField, HideInInspector] private Generator generatorScript;
    [SerializeField, HideInInspector] private CountNShowCoins CoinsScript;
    [SerializeField, HideInInspector] private LMBClicker LMBClicker;

    public void UpgradeGeneratorTime()
    {
        if (CoinsScript.currCoins >= upgradeTimeCost)
        {
            CoinsScript.AddCoins(-upgradeTimeCost);
            generatorScript.timeToProduce -= (float)0.2;
        }
    }
    public void UpgradeGeneratorCoins()
    {
        if (CoinsScript.currCoins >= upgradeCoinsCost)
        {
            CoinsScript.AddCoins(-upgradeCoinsCost);
            generatorScript.amountOfCoinsProducing += (float)0.5;
        }
    }
    public void UpgradeGeneratorExp()
    {
        if (CoinsScript.currCoins >= upgradeExpCost)
        {
            CoinsScript.AddCoins(-upgradeExpCost);
            generatorScript.amountOfExpProducing += (float)0.3;
        }
    }
    public void UpgradeLMBClicker()
    {
        if (CoinsScript.currCoins >= upgradeClickerCost)
        {
            CoinsScript.AddCoins(-upgradeClickerCost);
            LMBClicker.coinsPerLMB += 1;
        }
    }
}