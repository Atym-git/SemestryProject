using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorUpgrade : MonoBehaviour
{
    [SerializeField] private float upgradeTimeCost;
    [SerializeField] private float upgradeCoinsCost;
    [SerializeField] private float upgradeExpCost;

    [SerializeField, HideInInspector] private Generator generatorScript;
    [SerializeField, HideInInspector] private CountNShowCoins CoinsScript;

    public void UpgradeTimeConsume()
    {
        if (CoinsScript.currCoins > upgradeTimeCost)
        {
            CoinsScript.AddCoins(-upgradeTimeCost);
            generatorScript.timeToProduce -= (float)0.2;
        }
    }
    public void UpgradeCoinsGain()
    {
        if (CoinsScript.currCoins > upgradeCoinsCost)
        {
            CoinsScript.AddCoins(-upgradeCoinsCost);
            generatorScript.amountOfCoinsProducing += (float)0.5;
        }
    }
    public void UpgradeExpGain()
    {
        if (CoinsScript.currCoins > upgradeExpCost)
        {
            CoinsScript.AddCoins(-upgradeExpCost);
            generatorScript.amountOfExpProducing += (float)0.3;
        }
    }
}