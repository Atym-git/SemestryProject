using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{
    public Sprite workerSprite;

    public float workerCost;

    public float XPMultiplayer;

    public float coinsMultiplayer;

    public string workerName;

    private Generator generatorScript;

    public void SetupWorker(Sprite WorkerSprite, float WorkerCost, float WorkerXPMultiplayer, float WorkerCoinsMultiplayer, string WorkerName)
    {
        workerSprite = WorkerSprite;
        GetComponent<Image>().sprite = workerSprite;
        workerCost = WorkerCost;
        coinsMultiplayer = WorkerCoinsMultiplayer;
        XPMultiplayer = WorkerXPMultiplayer;
        workerName = WorkerName;
    }

    public void WorkerSet()
    {
        generatorScript = GetComponentInParent<Generator>();
        generatorScript.WorkerOnGenerator(coinsMultiplayer, XPMultiplayer);
    }
    public void WorkerOff()
    {
        generatorScript = GetComponentInParent<Generator>();
        generatorScript.WorkerOffGenerator(coinsMultiplayer, XPMultiplayer);
    }
}
