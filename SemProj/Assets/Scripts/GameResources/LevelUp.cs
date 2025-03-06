using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    private int currLevel = 1;

    [field: SerializeField, HideInInspector] private TextMeshProUGUI showLevelTMP;

    private GeneratorsUnlocker unlockerScript;

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

    public int GetcurrLvl()
    {
        return currLevel;
    }

    private void ShowLevel()
    {
        showLevelTMP.text = currLevel.ToString();
    }
}