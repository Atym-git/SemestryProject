using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPrefs : MonoBehaviour
{
    private CountNShowCoins coinsScript;
    private ExpGain expScript;
    private Save saveScript;
    private GeneratorPlacer generatorPlacer;

    private string[] _slidersKeys;
    private List<string> _generatorsKeys = new List<string>();
    private List<string> _workersKeys = new List<string>();
    private string[] _resourcesKeys;

    private void Start()
    {
        saveScript = GetComponent<Save>();
        expScript = SingleToneManager.expScript;
        coinsScript = SingleToneManager.coinsScript;
        GetKeys();
        generatorPlacer = GetComponent<GeneratorPlacer>();
        Load();
    }

    private void GetKeys()
    {
        _slidersKeys = saveScript.GetSlidersKeys();
        _generatorsKeys = saveScript.GetGeneratorsKeys();
        _workersKeys = saveScript.GetWorkersKeys();
        _resourcesKeys = saveScript.GetResourceKeys();
    }

    private void Load()
    {
        coinsScript.AddCoins(PlayerPrefs.GetFloat(_resourcesKeys[0]));
        expScript.OnExpGain(PlayerPrefs.GetFloat(_resourcesKeys[1]));
        GeneratorSO[] generatorSOs = generatorPlacer.GetGeneratorsSO();
        WorkersSO[] workerSOs = generatorPlacer.GetWorkersSOs();
        for (int i = 0; i < generatorSOs.Length; i++)
        {

            if (PlayerPrefs.HasKey(_generatorsKeys[i]))
            {
                coinsScript.AddCoins(generatorSOs[i].generatorCost);
                generatorPlacer.BuyGenerator(i);
            }
        }
        for (int i = 0; i < workerSOs.Length; i++)
        {
            Debug.Log(_workersKeys.Count);
            Debug.Log(_workersKeys[i]);
            if (PlayerPrefs.HasKey(_workersKeys[i]))
            {
                coinsScript.AddCoins(workerSOs[i].workerCost);
                generatorPlacer.BuyGenerator(i);
            }
        }
    }

    public void SetSlidersValue()
    {
        saveScript.volumeSliders[0].value = PlayerPrefs.GetFloat(_slidersKeys[0]);
        saveScript.volumeSliders[1].value = PlayerPrefs.GetFloat(_slidersKeys[1]);
        saveScript.volumeSliders[2].value = PlayerPrefs.GetFloat(_slidersKeys[2]);
    }


}
