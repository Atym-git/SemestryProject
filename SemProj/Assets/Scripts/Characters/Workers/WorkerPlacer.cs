using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WorkerPlacer : MonoBehaviour
{
    [SerializeField] private GameObject _workerPrefab;
    [SerializeField] private Transform _workersRootParent;

    [SerializeField] List<Transform> _workersRoots = new List<Transform>();

    private WorkersSO[] workersSOs;

    List<int> workerIds = new List<int>();

    [SerializeField] private CountNShowCoins coinsScript;

    private void Awake()
    {
        ResourceLoader();
        for (int i = 0; i < _workersRootParent.childCount; i++)
        {
            //Debug.Log(_workersRoots[i]);
            //Debug.Log(_workersRootParent.GetChild(i).transform);
            _workersRoots.Add(_workersRootParent.GetChild(i).transform);
        }
    }

    public void OnWorkerBought(int workerId)
    {
        if (coinsScript.IsEnoughToBuy(workersSOs[workerId].workerCost) && workerId < workersSOs.Length &&
            !workerIds.Contains(workerId))
        {
            var randomSpawnPointId = Random.Range(0, _workersRoots.Count);
            GameObject instance = Instantiate(_workerPrefab, _workersRoots[randomSpawnPointId]);

            Worker worker = instance.GetComponent<Worker>();

            worker.SetupWorker(workersSOs[workerId].workerSprite, workersSOs[workerId].workerCost, workersSOs[workerId].coinsMultiplayer,
                workersSOs[workerId].XPMultiplayer, workersSOs[workerId].workerName);

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
