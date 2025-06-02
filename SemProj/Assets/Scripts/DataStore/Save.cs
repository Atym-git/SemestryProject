using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GeneratorPlacer))]
[RequireComponent(typeof(Level))]
public class Save : MonoBehaviour
{
    public Slider[] volumeSliders;

    private CountNShowCoins coinsScript;
    private ExpGain expScript;
    private LoadPrefs loadScript;
    private GeneratorPlacer generatorPlacer;
    private Level levelUp;

    private string[] _slidersKeys = { "MainSlider", "MusicSlider", "SFXSlider" };

    private string[] _resourceKeys = { "Coins", "Level", "Exp" };

    private List<string> generatorsKeys = new List<string>();

    private List<string> workersKeys = new List<string>();

    private string danceFloorKey = "DanceFloor";

    private void Awake()
    {
        GetScriptsLinks();
        if (generatorPlacer != null)
        {
            for (int i = 0; i < generatorPlacer.GetGeneratorsSO().Length; i++)
            {
                generatorsKeys.Add($"Generator-{i}");
                //Debug.Log($"Generator-{i}");
            }
            for (int i = 0; i < generatorPlacer.GetWorkersSOs().Length; i++)
            {
                workersKeys.Add($"Worker-{i}");
            }
        }
    }

    private void GetScriptsLinks()
    {
        expScript = SingleToneManager.expScript;
        coinsScript = SingleToneManager.coinsScript;
        loadScript = GetComponent<LoadPrefs>();
        generatorPlacer = GetComponent<GeneratorPlacer>();
        levelUp = GetComponent<Level>();
    }

    private void Update()
    {
        RestartGame();
    }

    private void RestartGame()
    {
        coinsScript = SingleToneManager.coinsScript;
        expScript = SingleToneManager.expScript;
        levelUp = GetComponent<Level>();

        if (Input.GetKeyDown(KeyCode.R))
        {
            coinsScript.AddCoins(-coinsScript.GetCoins());
            expScript.GainExp(-expScript.currExp);
            levelUp.SetCurrLevel(1);
            PlayerPrefs.DeleteAll();
            Transform[] generatorsRoots = generatorPlacer.GetGeneratorRoots();
            Transform[] workersRoots = generatorPlacer.GetWorkerRoots();
            DestroyBoughtResources(generatorsRoots);
            DestroyBoughtResources(workersRoots);
            loadScript.LoadAll();
        }
    }

    private void DestroyBoughtResources(Transform[] roots)
    {
        //foreach (Transform t in roots)
        //{
        //    if (t.GetComponentInChildren<Worker>())
        //    {
        //        Destroy(t.GetChild(0));
        //    }
        //    else
        //    {
        //        //List<Transform> generatorRoots = new List<Transform>();
        //        for (int i = 0; i < roots.Length; i++)
        //        {
        //            for (int j = 0; j < roots[i].childCount; j++)
        //            {
        //                //generatorRoots.Add(roots[i].GetChild(j));
        //                Destroy(roots[i].GetChild(j).GetChild(0));
        //            }
        //        }
        //    }
        //}
    }

    private void SaveSlidersVolume()
    {
        PlayerPrefs.SetFloat(_slidersKeys[0], volumeSliders[0].value);
        PlayerPrefs.SetFloat(_slidersKeys[1], volumeSliders[1].value);
        PlayerPrefs.SetFloat(_slidersKeys[2], volumeSliders[2].value);
    }

    private void SaveGameResources()
    {
        coinsScript = SingleToneManager.coinsScript;
        expScript = SingleToneManager.expScript;
        levelUp = GetComponent<Level>();

        int currLevel = levelUp.GetCurrLvl();
        int currCoins = coinsScript.GetCoins();
        PlayerPrefs.SetFloat(_resourceKeys[0], currCoins);
        PlayerPrefs.SetInt(_resourceKeys[1], currLevel);
        PlayerPrefs.SetFloat(_resourceKeys[2], expScript.currExp);
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

    public void SaveDanceFloorUpgrade()
    {
        PlayerPrefs.SetInt(danceFloorKey, 1);
    }

    private void OnApplicationQuit()
    {
        SaveSlidersVolume();
        SaveGameResources();
    }
    public List<string> GetGeneratorsKeys() => generatorsKeys;
    public List<string> GetWorkersKeys() => workersKeys;
    public string[] GetResourceKeys() => _resourceKeys;
    public string[] GetSlidersKeys() => _slidersKeys;
}
