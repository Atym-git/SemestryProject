using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public Slider[] volumeSliders;

    private CountNShowCoins coinsScript;
    private ExpGain expScript;
    private Save saveScript;

    private string[] _slidersKeys = { "MainSlider", "MusicSlider", "SFXSlider" };

    private string[] _resourceKeys = { "Coins", "Exp" };

    private void Start()
    {
        expScript = Manager.expScript;
        coinsScript = Manager.coinsScript;
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

    private void OnApplicationQuit()
    {
        SaveSlidersVolume();
        SaveCoinsNExp();
    }
}
