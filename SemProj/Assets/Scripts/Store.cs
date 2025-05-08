using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private int upgradeTimeCost;
    [SerializeField] private int upgradeCoinsCost;
    [SerializeField] private int upgradeExpCost;
    [SerializeField] private int upgradeClickerCost;

    [Header("MultiplyAfterUpgrade")]
    [SerializeField] private float _generatorTime = 1.5f;
    [SerializeField] private float _generatorCoins = 1.5f;
    [SerializeField] private float _generatorExp = 1.5f;
    [SerializeField] private float _lmbClicker = 1.5f;

    [SerializeField, HideInInspector] private TextMeshProUGUI showUpgradeClickerCost;

    [SerializeField, HideInInspector] private Generator generatorScript;
    [SerializeField] private CountNShowCoins coinsScript;
    [SerializeField, HideInInspector] private LMBClicker LMBClicker;

    //public void UpgradeGeneratorTime()
    //{
    //    if (coinsScript.IsEnoughToBuy(upgradeTimeCost))
    //    {
    //        coinsScript.AddCoins(-upgradeTimeCost);
    //        upgradeTimeCost *= _generatorTime;
    //        generatorScript.timeToProduce -= 0.2f;
    //    }
    //}
    //public void UpgradeGeneratorCoins()
    //{
    //    if (coinsScript.IsEnoughToBuy(upgradeCoinsCost))
    //    {
    //        coinsScript.AddCoins(-upgradeCoinsCost);
    //        upgradeCoinsCost *= _generatorCoins;
    //        generatorScript.coinsProducement += 0.5f;
    //    }
    //}
    //public void UpgradeGeneratorExp()
    //{
    //    if (coinsScript.IsEnoughToBuy(upgradeExpCost))
    //    {
    //        coinsScript.AddCoins(-upgradeExpCost);
    //        upgradeExpCost *= Mathf.RoundToInt(upgradeExpCost * upgra);
    //        generatorScript.expProducement += 0.3f;
    //    }
    //}
    public void UpgradeLMBClicker()
    {
        if (coinsScript.IsEnoughToBuy(upgradeClickerCost))
        {
            coinsScript.AddCoins(-upgradeClickerCost);
            upgradeClickerCost = Mathf.RoundToInt(upgradeClickerCost * _lmbClicker);
            showUpgradeClickerCost.text = upgradeClickerCost.ToString();
            LMBClicker.coinsPerLMB += 1;
        }
    }
}