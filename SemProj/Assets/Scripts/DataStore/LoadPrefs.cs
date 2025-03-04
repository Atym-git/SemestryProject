using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPrefs : MonoBehaviour
{
    private CountNShowCoins coinsScript;
    private ExpGain expScript;
    private Save saveScript;

    private string[] _slidersKeys = { "MainSlider", "MusicSlider", "SFXSlider" };

    private void Start()
    {
        expScript = Manager.expScript;
        coinsScript = Manager.coinsScript;
        saveScript = GetComponent<Save>();
        PlayerPrefs.GetFloat("Coins");
        PlayerPrefs.GetFloat("Exp");
    }

    public void SetSlidersValue()
    {
        saveScript.volumeSliders[0].value = PlayerPrefs.GetFloat(_slidersKeys[0]);
        saveScript.volumeSliders[1].value = PlayerPrefs.GetFloat(_slidersKeys[1]);
        saveScript.volumeSliders[2].value = PlayerPrefs.GetFloat(_slidersKeys[2]);
    }


}
