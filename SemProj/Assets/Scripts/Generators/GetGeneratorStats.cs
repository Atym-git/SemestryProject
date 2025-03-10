using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetGeneratorStats : MonoBehaviour
{
    [SerializeField] private Image generatorImage;

    [SerializeField] private TextMeshProUGUI coinsTMP;
    [SerializeField] private TextMeshProUGUI expTMP;
    [SerializeField] private TextMeshProUGUI timeTMP;

    public void GetStats(Sprite generatorSprite, float coinsProduc, float expProduc, float timeProduc)
    {
        generatorImage.sprite = generatorSprite;
        coinsTMP.text = coinsProduc.ToString();
        expTMP.text = expProduc.ToString();
        timeTMP.text = timeProduc.ToString();
    }
}
