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

    private void Start()
    {
        expScript = Manager.expScript;
        coinsScript = Manager.coinsScript;
    }

    public void SaveSlidersVolume()
    {
        PlayerPrefs.SetFloat("MainSlider", volumeSliders[0].value);
        PlayerPrefs.SetFloat("MusicSlider", volumeSliders[1].value);
        PlayerPrefs.SetFloat("SFXSlider", volumeSliders[2].value);
    }

    public void SaveCoinsNExp()
    {
        PlayerPrefs.SetFloat("Coins", coinsScript.currCoins);
        PlayerPrefs.SetFloat("Exp", expScript.currExp);
    }
}
