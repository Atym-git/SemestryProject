using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WorkerPlacer : MonoBehaviour
{
    [SerializeField] private GameObject _workerPrefab;
    [SerializeField] private Transform _workersRoot;

    private WorkersSO[] workersSOs;

    List<int> workerIds = new List<int>();

    [SerializeField] private CountNShowCoins coinsScript;

    private void Awake()
    {
        ResourceLoader();
    }

    public void OnWorkerBought(int workerId)
    {
        if (coinsScript.IsEnoughToBuy(workersSOs[workerId].workerCost) && workerId < workersSOs.Length &&
            !workerIds.Contains(workerId))
        {

            GameObject instance = Instantiate(_workerPrefab, _workersRoot);

            Worker worker = instance.GetComponent<Worker>();

            worker.SetupWorker(workersSOs[workerId].workerSprite, workersSOs[workerId].workerCost, workersSOs[workerId].workerCoinsMultiplayer,
                workersSOs[workerId].workerXPMultiplayer);

            workerIds.Add(workerId);
            coinsScript.AddCoins(-workersSOs[workerId].workerCost);
        }

    }

    private void ResourceLoader()
    {
        workersSOs = Resources.LoadAll("SO/WorkersSO", typeof(WorkersSO))
        .Cast<WorkersSO>()
        .ToArray();
    }

    public WorkersSO[] GetWorkersSOs() => workersSOs;
}
