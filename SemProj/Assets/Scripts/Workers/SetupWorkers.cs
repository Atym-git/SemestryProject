using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupWorkers : MonoBehaviour
{
    private float generatorXPMultiplayer;

    private float generatorCoinsMultiplayer;

    private Generator generatorScript;
    public void SetupWorker(Sprite WorkerSprite, float GeneratorXPMultiplayer, float GeneratorCoinsMultiplayer)
    {
        GetComponent<Image>().sprite = WorkerSprite;
        generatorCoinsMultiplayer = GeneratorCoinsMultiplayer;
        generatorXPMultiplayer = GeneratorXPMultiplayer;
    }

    public void OnWorkerSet()
    {
        generatorScript = GetComponentInParent<Generator>();
        generatorScript.WorkerOnGenerator(generatorCoinsMultiplayer, generatorXPMultiplayer);
    }
}
