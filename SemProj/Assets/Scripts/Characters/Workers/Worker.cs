using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{
    private float workerCost;

    private float workerXPMultiplayer;

    private float workerCoinsMultiplayer;

    private Generator generatorScript;

    public void SetupWorker(Sprite WorkerSprite, float WorkerCost, float WorkerXPMultiplayer, float WorkerCoinsMultiplayer)
    {
        GetComponent<Image>().sprite = WorkerSprite;
        workerCost = WorkerCost;
        workerCoinsMultiplayer = WorkerCoinsMultiplayer;
        workerXPMultiplayer = WorkerXPMultiplayer;
    }

    public void WorkerSet()
    {
        generatorScript = GetComponentInParent<Generator>();
        generatorScript.WorkerOnGenerator(workerCoinsMultiplayer, workerXPMultiplayer);
    }
    public void WorkerOff()
    {
        generatorScript = GetComponentInParent<Generator>();
        generatorScript.WorkerOffGenerator(workerCoinsMultiplayer, workerXPMultiplayer);
    }
}
