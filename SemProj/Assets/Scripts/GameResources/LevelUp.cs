using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    private int currLevel = 1;

    [SerializeField] private TextMeshProUGUI showLevelTMP;

    [SerializeField] private ExpGain expGain;

    [SerializeField] private GeneratorsUnlocker unlockerScript;

    public void LevelUpgraded()
    {
        currLevel += 1;
        ShowLevel();
        unlockerScript.Unlock(currLevel);
    }

    public bool SetCurrLevel(int level)
    {
        if (level == 0)
        {
            return false;
        }
        currLevel = level;
        expGain.AllignExpNLevel(level);
        ShowLevel();
        unlockerScript.Unlock(currLevel);
        return true;
    }
    public int GetcurrLvl()
    {
        return currLevel;
    }

    private void ShowLevel()
    {
        showLevelTMP.text = currLevel.ToString();
    }
}