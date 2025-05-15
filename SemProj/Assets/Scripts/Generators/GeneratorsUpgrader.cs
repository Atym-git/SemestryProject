using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorsUpgrader : MonoBehaviour
{
    private List<int> generatorsLevels = new List<int>();
    private const int generatorsStartingLevel = 1;
    [SerializeField] private int generatorsMaxLevel = 3;

    [SerializeField] private Button[] upgradeButtons;
    private Transform[] generatorsRoots;
    private GeneratorSO[] generatorSOs;

    [SerializeField] private TextMeshProUGUI[] coinsTMPs;
    [SerializeField] private TextMeshProUGUI[] expTMPs;
    [SerializeField] private TextMeshProUGUI[] timeTMPs;
    [SerializeField] private TextMeshProUGUI currLevelTMP;

    [SerializeField] private float coinsUpgrade = 1.5f; // From level 1 to 2
    [SerializeField] private float expUpgrade = 1.25f;
    [SerializeField] private float timeUpgrade = 1.1f;

    [SerializeField] private float multiplierAfterUpgrade = 1.5f;

    [SerializeField] private int upgradeCost = 100;

    //[SerializeField] private float coinsSecondUpgrade = 1.5f;
    //[SerializeField] private float expSecondUpgrade = 1.25f;
    //[SerializeField] private float timeSecondUpgrade = 1.1f;

    [SerializeField] private Sprite[,] spritesByLevels;

    [SerializeField] private Sprite[] level1Sprites;
    [SerializeField] private Sprite[] level2Sprites;
    [SerializeField] private Sprite[] level3Sprites;

    private Generator generator;
    private GeneratorPlacer generatorPlacerScript;
    private Save save;
    private CountNShowCoins coins;

    private void Start()
    {
        save = GetComponent<Save>();
        coins = GetComponent<CountNShowCoins>();

        GetGeneratorValues();
    }

    private void GetGeneratorValues()
    {
        generatorPlacerScript = GetComponent<GeneratorPlacer>();

        generatorsRoots = generatorPlacerScript.GetGeneratorRoots();
        generatorSOs = generatorPlacerScript.GetGeneratorsSO();

        for (int i = 0; i < generatorSOs.Length; i++)
        {
            generatorsLevels.Add(generatorsStartingLevel);
        }
    }
    
    public void UpgradeGenerator(int Id)
    {
        if (coins.IsEnoughToBuy(upgradeCost))
        {
            int generatorLevel = generator.generatorLevel;
            if (generatorsLevels[Id] == 1)
            {
                generatorLevel++;
                
                //generator.UpgradeGenerator();
            }
            else if (generatorsLevels[Id] == 2)
            {
                generatorLevel++;
                IsMaxLevel(Id);
            }
            ChangeSprite(Id, generator);
            upgradeCost = Mathf.RoundToInt(upgradeCost * multiplierAfterUpgrade);
        }
        //save.SaveGenerator(Id);
    }

    private void IsMaxLevel(int Id)
    {
        upgradeButtons[Id].interactable = false;
    }
    public void ShowStats(int Id)
    {
        generator = generatorsRoots[Id].GetComponentInChildren<Generator>();

        currLevelTMP.text = generatorsLevels[Id].ToString();
        coinsTMPs[0].text = generator.coinsProducement.ToString();
        coinsTMPs[1].text = (generator.coinsProducement * coinsUpgrade).ToString();
        expTMPs[0].text = generator.expProducement.ToString();
        expTMPs[1].text = (generator.expProducement * expUpgrade).ToString();
        timeTMPs[0].text = generator.timeToProduce.ToString();
        timeTMPs[1].text = (generator.timeToProduce / timeUpgrade).ToString();
        //ChangeSprite(Id, generator);
    }

    private void ChangeSprite(int Id, Generator generator)
    {
        Image generatorImage = generator.GetComponent<Image>();

        bool hasSprites = level1Sprites[Id] || level2Sprites[Id] || level3Sprites[Id];

        if (generatorImage && hasSprites)
        {
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
                //IsMaxLevel(Id);
            }
        }
    }
}
