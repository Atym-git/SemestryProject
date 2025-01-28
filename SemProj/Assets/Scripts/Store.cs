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
            upgradeTimeCost *= 1.5f;
            generatorScript.timeToProduce -= 0.2f;
        }
    }
    public void UpgradeGeneratorCoins()
    {
        if (CoinsScript.currCoins >= upgradeCoinsCost)
        {
            CoinsScript.AddCoins(-upgradeCoinsCost);
            generatorScript.amountOfCoinsProducing += 0.5f;
        }
    }
    public void UpgradeGeneratorExp()
    {
        if (CoinsScript.currCoins >= upgradeExpCost)
        {
            CoinsScript.AddCoins(-upgradeExpCost);
            generatorScript.amountOfExpProducing += 0.3f;
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