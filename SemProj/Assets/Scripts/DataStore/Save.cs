using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public Slider[] volumeSliders;

    private CountNShowCoins coinsScript;
    private ExpGain expScript;
    private Save saveScript;
    private GeneratorPlacer generatorPlacer;

    private string[] _slidersKeys = { "MainSlider", "MusicSlider", "SFXSlider" };

    private string[] _resourceKeys = { "Coins", "Exp" };

    private List<string> generatorsKeys = new List<string>();

    private List<string> workersKeys = new List<string>();

    private void Awake()
    {
        expScript = SingleToneManager.expScript;
        coinsScript = SingleToneManager.coinsScript;
        generatorPlacer = GetComponent<GeneratorPlacer>();
        Worker workers = GetComponent<Worker>();
        if (generatorPlacer != null)
        {
            for (int i = 0; i < generatorPlacer.GetGeneratorsSO().Length; i++)
            {
                generatorsKeys.Add($"Generator-{i}");
            }
            for (int i = 0; i < generatorPlacer.GetWorkersSOs().Length; i++)
            {
                workersKeys.Add($"Worker-{i}");
            }
        }
    }

    public void SaveSlidersVolume()
    {
        PlayerPrefs.SetFloat(_slidersKeys[0], volumeSliders[0].value);
        PlayerPrefs.SetFloat(_slidersKeys[1], volumeSliders[1].value);
        PlayerPrefs.SetFloat(_slidersKeys[2], volumeSliders[2].value);
    }

    public void SaveCoinsNExp()
    {
        PlayerPrefs.SetFloat(_resourceKeys[0], coinsScript.SaveCoins());
        PlayerPrefs.SetFloat(_resourceKeys[1], expScript.currExp);
    }

    public void SaveGenerator(int Id)
    {
        PlayerPrefs.SetInt(generatorsKeys[Id].ToString(), Id);
    }
    public void SaveWorkers(int Id)
    {
        int workerId = Id - generatorPlacer.GetGeneratorsSO().Length;
        PlayerPrefs.SetInt(workersKeys[workerId].ToString(), workerId);
    }

    private void OnApplicationQuit()
    {
        SaveSlidersVolume();
        SaveCoinsNExp();
    }
    public List<string> GetGeneratorsKeys() => generatorsKeys;
    public List<string> GetWorkersKeys() => workersKeys;
    public string[] GetResourceKeys() => _resourceKeys;
    public string[] GetSlidersKeys() => _slidersKeys;
}
