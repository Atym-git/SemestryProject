using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int currLevel = 1;
    private int maxLevel;

    [SerializeField] private TextMeshProUGUI showLevelTMP;

    [SerializeField] private GeneratorsUnlocker unlockerScript;
    [SerializeField] private CustomersSpawner customersSpawner;

    public void LevelUpgraded()
    {
        if (currLevel < maxLevel)
        {
            currLevel++;
            ShowLevel();
            unlockerScript.Unlock(currLevel);
            customersSpawner.SpawnCustomers(currLevel, 1);
        }
    }

    public bool SetCurrLevel(int level)
    {
        if (level == 0)
        {
            return false;
        }

        //for (int i = 1; i <= level; i++)
        //{
        //    LevelUpgraded();
        //}

        if (level <= maxLevel)
        {
            currLevel = level;
            ShowLevel();
            unlockerScript.Unlock(currLevel);
            int customersSpawnAmount = currLevel / 2;
            customersSpawner.SpawnCustomers(currLevel, customersSpawnAmount);
        }
        return true;
    }

    public void SetMaxLevel(int level) => maxLevel = level;
    public int GetCurrLvl() => currLevel;

    private void ShowLevel()
    {
        showLevelTMP.text = currLevel.ToString();
    }
}