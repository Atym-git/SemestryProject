using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    private int currLevel;

    [field: SerializeField, HideInInspector] private TextMeshProUGUI showLevelTMP;

    public void LevelUpgraded()
    {
        currLevel += 1;
        ShowLevel();
    }

    private void ShowLevel()
    {
        showLevelTMP.text = currLevel.ToString();
    }
}