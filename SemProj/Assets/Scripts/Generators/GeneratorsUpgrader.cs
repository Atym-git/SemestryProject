using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorsUpgrader : MonoBehaviour
{
    private int[] generatorsLevels;
    private const int generatorsStartingLevel = 1;
    [SerializeField] private int generatorsMaxLevel = 3;

    [SerializeField] private Button[] upgradeButtons;
    private Transform[] generatorsRoots;
    private GeneratorSO[] generatorSOs;

    [SerializeField] private TextMeshProUGUI[] coinsTMPs;
    [SerializeField] private TextMeshProUGUI[] expTMPs;
    [SerializeField] private TextMeshProUGUI[] timeTMPs;
    [SerializeField] private TextMeshProUGUI currLevelTMP;

    [SerializeField] private float coinsFirstUpgrade = 1.5f; // From level 1 to 2
    [SerializeField] private float expFirstUpgrade = 1.25f;
    [SerializeField] private float timeFirstUpgrade = 1.1f;

    [SerializeField] private float multiplierAfterUpgrade = 1.5f;

    //[SerializeField] private float coinsSecondUpgrade = 1.5f;
    //[SerializeField] private float expSecondUpgrade = 1.25f;
    //[SerializeField] private float timeSecondUpgrade = 1.1f;

    [SerializeField] private Sprite[] level1Sprites;
    [SerializeField] private Sprite[] level2Sprites;
    [SerializeField] private Sprite[] level3Sprites;

    //private Generator generator;
    private GeneratorPlacer generatorPlacerScript;
    private Save save;
    private void Start()
    {
        generatorPlacerScript = GetComponent<GeneratorPlacer>();
        save = GetComponent<Save>();
        generatorsRoots = generatorPlacerScript.GetGeneratorRoots();
        generatorSOs = generatorPlacerScript.GetGeneratorsSO();
        for (int i = 0; i < generatorSOs.Length; i++)
        {
            generatorsLevels[i] = generatorsStartingLevel;
        }
    }
    
    public void UpgradeGenerator(int Id)
    {
        if (generatorsLevels[Id] == 1)
        {
            generatorsLevels[Id]++;
            Generator generator = generatorsRoots[Id].GetComponentInChildren<Generator>();
        }
        else if (generatorsLevels[Id] == 2)
        {
            generatorsLevels[Id]++;
            IsMaxLevel(Id);
        }
        //save.SaveGenerator(Id);
    }

    private void IsMaxLevel(int Id)
    {
        upgradeButtons[Id].interactable = false;
    }
    public void ShowStats(int Id)
    {
        Generator generator = generatorsRoots[Id].GetComponentInChildren<Generator>();
        currLevelTMP.text = generatorsLevels[Id].ToString();
        coinsTMPs[0].text = generator.coinsProducement.ToString();
        coinsTMPs[1].text = (generator.coinsProducement * coinsFirstUpgrade).ToString();
        expTMPs[0].text = generator.expProducement.ToString();
        expTMPs[1].text = (generator.expProducement * coinsFirstUpgrade).ToString();
        timeTMPs[0].text = generator.timeToProduce.ToString();
        timeTMPs[1].text = (generator.timeToProduce * coinsFirstUpgrade).ToString();
        Image generatorImage = generator.GetComponent<Image>();
        if (generatorsLevels[Id] == 1)
        {
            generatorImage.sprite = level1Sprites[Id];
        }
        if (generatorsLevels[Id] == 2)
        {
            generatorImage.sprite = level2Sprites[Id];
        }
        else if (generatorsLevels[Id] == 3)
        {
            generatorImage.sprite = level3Sprites[Id];
            IsMaxLevel(Id);
        }
    }
}
