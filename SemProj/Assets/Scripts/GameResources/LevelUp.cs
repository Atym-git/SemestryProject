using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public int currLevel = 1;

    [SerializeField] private TextMeshProUGUI showLevelTMP;

    [SerializeField] private GeneratorsUnlocker unlockerScript;

    private void Start()
    {
        unlockerScript = GetComponent<GeneratorsUnlocker>();
    }

    public void LevelUpgraded()
    {
        currLevel += 1;
        ShowLevel();
        unlockerScript.Unlock(currLevel);
    }

    public bool SetCurrLevel(int level)
    {
        if (level != 0)
        {
            return false;
        }
        currLevel = level;
        return true;
    }
    //public int GetcurrLvl()
    //{
    //    return currLevel;
    //}

    private void ShowLevel()
    {
        showLevelTMP.text = currLevel.ToString();
    }
}