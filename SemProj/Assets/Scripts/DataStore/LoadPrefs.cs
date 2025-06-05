using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Save))]
[RequireComponent(typeof(GeneratorPlacer))]
[RequireComponent(typeof(Level))]
public class LoadPrefs : MonoBehaviour
{
    private CountNShowCoins coinsScript;
    private ExpGain expScript;
    private Save saveScript;
    private GeneratorPlacer generatorPlacer;
    private Level levelUp;
    [SerializeField] private LMBClicker DFUpgrader;

    private string[] _slidersKeys;
    private List<string> _generatorsKeys = new List<string>();
    private List<string> _workersKeys = new List<string>();
    private string[] _resourcesKeys;

    private void Start()
    {
        saveScript = GetComponent<Save>();
        expScript = SingleToneManager.expScript;
        coinsScript = SingleToneManager.coinsScript;
        generatorPlacer = GetComponent<GeneratorPlacer>();
        levelUp = GetComponent<Level>();
        GetKeys();
        LoadAll();
    }

    private void GetKeys()
    {
        _slidersKeys = saveScript.GetSlidersKeys();
        _generatorsKeys = saveScript.GetGeneratorsKeys();
        _workersKeys = saveScript.GetWorkersKeys();
        _resourcesKeys = saveScript.GetResourceKeys();
    }

    public void LoadAll()
    {
        LoadResources();
        GeneratorSO[] generatorSOs = generatorPlacer.GetGeneratorsSO();
        WorkersSO[] workerSOs = generatorPlacer.GetWorkersSOs();
        LoadGenerators(generatorSOs);
        LoadWorkers(workerSOs);
        LoadDFUpgrade();
    }

    private void LoadResources()
    {
        coinsScript.AddCoins(PlayerPrefs.GetFloat(_resourcesKeys[0]));
        levelUp.SetCurrLevel(PlayerPrefs.GetInt(_resourcesKeys[1]));
        expScript.GainExp(PlayerPrefs.GetFloat(_resourcesKeys[2]));
        //Debug.Log(PlayerPrefs.GetInt(_resourcesKeys[1]));
    }

    private void LoadGenerators(GeneratorSO[] generatorSOs)
    {
        for (int i = 0; i < generatorSOs.Length; i++)
        {
            if (PlayerPrefs.HasKey(_generatorsKeys[i]))
            {
                coinsScript.AddCoins(generatorSOs[i].generatorCost);
                generatorPlacer.BuyGeneratorOrWorker(i);
            }
        }
    }
    private void LoadWorkers(WorkersSO[] workerSOs)
    {
        for (int i = 0; i < workerSOs.Length; i++)
        {
            if (PlayerPrefs.HasKey(_workersKeys[i]))
            {
                coinsScript.AddCoins(workerSOs[i].workerCost);
                //Debug.Log(_workersKeys[i]);
                //Debug.Log(i);
                generatorPlacer.BuyGeneratorOrWorker(i+_generatorsKeys.Count);
            }
        }
    }

    private void LoadDFUpgrade()
    {
        if (PlayerPrefs.GetInt("DanceFloor") == 1)
        {
            coinsScript.AddCoins(30);
            DFUpgrader.DanceFloorUpgrade();
        }
    }

    public void SetSlidersValue()
    {
        saveScript.volumeSliders[0].value = PlayerPrefs.GetFloat(_slidersKeys[0]);
        saveScript.volumeSliders[1].value = PlayerPrefs.GetFloat(_slidersKeys[1]);
        saveScript.volumeSliders[2].value = PlayerPrefs.GetFloat(_slidersKeys[2]);
    }

}
