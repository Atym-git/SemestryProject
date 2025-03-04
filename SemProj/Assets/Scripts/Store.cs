using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private float upgradeTimeCost;
    [SerializeField] private float upgradeCoinsCost;
    [SerializeField] private float upgradeExpCost;
    [SerializeField] private float upgradeClickerCost;

    [SerializeField, HideInInspector] private TextMeshProUGUI showUpgradeClickerCost;

    [SerializeField, HideInInspector] private Generator generatorScript;
    [SerializeField, HideInInspector] private CountNShowCoins coinsScript;
    [SerializeField, HideInInspector] private LMBClicker LMBClicker;

    public void UpgradeGeneratorTime()
    {
        if (coinsScript.IsEnoughToBuy(upgradeTimeCost))
        {
            coinsScript.AddCoins(-upgradeTimeCost);
            upgradeTimeCost *= 1.5f;
            generatorScript.timeToProduce -= 0.2f;
        }
    }
    public void UpgradeGeneratorCoins()
    {
        if (coinsScript.IsEnoughToBuy(upgradeCoinsCost))
        {
            coinsScript.AddCoins(-upgradeCoinsCost);
            generatorScript.coinsProducement += 0.5f;
        }
    }
    public void UpgradeGeneratorExp()
    {
        if (coinsScript.IsEnoughToBuy(upgradeExpCost))
        {
            coinsScript.AddCoins(-upgradeExpCost);
            generatorScript.expProducement += 0.3f;
        }
    }
    public void UpgradeLMBClicker()
    {
        if (coinsScript.IsEnoughToBuy(upgradeClickerCost))
        {
            coinsScript.AddCoins(-upgradeClickerCost);
            upgradeClickerCost *= 1.2f;
            showUpgradeClickerCost.text = upgradeClickerCost.ToString();
            LMBClicker.coinsPerLMB += 1;
        }
    }
}