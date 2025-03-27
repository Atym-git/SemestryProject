using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneratorPlacer : MonoBehaviour
{
    [SerializeField, HideInInspector] private GameObject generatorPrefab;
    [SerializeField] private GameObject _workerPrefab;

    [SerializeField] private Transform rootsParent;
    [SerializeField] private Transform[] generatorRoots;
    
    [SerializeField] private Transform _workersRootParent;
    [SerializeField] List<Transform> _workersRoots = new List<Transform>();

    private GeneratorSO[] generatorSOs;
    private WorkersSO[] workersSOs;
    private Worker[] workers;

    List<int> generatorIds = new List<int>();
    List<int> workerIds = new List<int>();

    [SerializeField] private GameObject _dialoguePanel;

    private const int _idTrigger = 0;

    [SerializeField] private int _dialogueCloseTime = 8;

    [SerializeField, HideInInspector] private CountNShowCoins coinsScript;

    private GeneratorsInStock generatorsStockScript;

    private void Awake()
    {
        generatorsStockScript = GetComponent<GeneratorsInStock>();
        ResourceLoader();
        
        for (int i = 0; i < generatorSOs.Length; i++)
        {
            generatorRoots[i] = rootsParent.GetChild(i);
        }
        for (int i = 0; i < _workersRootParent.childCount; i++)
        {
            _workersRoots.Add(_workersRootParent.GetChild(i).transform);
        }
    }

    public void BuyGenerator(int Id)
    {
        Debug.Log($"Id: {Id}");
        Debug.Log($"SO Length: {generatorSOs.Length}");
        if (Id < generatorSOs.Length)
        {
            if (coinsScript.IsEnoughToBuy(generatorSOs[Id].generatorCost) && Id < generatorSOs.Length &&
            !generatorIds.Contains(Id))
            {
                GameObject instance = Instantiate(generatorPrefab, generatorRoots[Id]);

                Generator generator = instance.GetComponent<Generator>();

                generator.SetupGenerator(generatorSOs[Id].generatorSprite, generatorSOs[Id].timeConsume,
                    generatorSOs[Id].coinsProducement, generatorSOs[Id].expProducement,
                    generatorSOs[Id].generatorCost, generatorSOs[Id].ScaleFactor);

                generatorIds.Add(Id);
                coinsScript.AddCoins(-generatorSOs[Id].generatorCost);

                generatorsStockScript.UpdateInStockGenerators(Id, generatorSOs.Length);
                if (Id == _idTrigger)
                {
                    StartCoroutine(Delay());
                }
            }
        }
        else
        {
            var workerSOId = Id - generatorSOs.Length;
            if (coinsScript.IsEnoughToBuy(workersSOs[workerSOId].workerCost) && workerSOId < workersSOs.Length &&
            !workerIds.Contains(workerSOId))
            {
                Debug.Log($"Else {Id}");
                GameObject instance = Instantiate(_workerPrefab, _workersRoots[workerSOId]);

                Worker worker = instance.GetComponent<Worker>();

                worker.SetupWorker(workersSOs[workerSOId].workerSprite, workersSOs[workerSOId].workerCost,
                    workersSOs[workerSOId].coinsMultiplayer, workersSOs[workerSOId].XPMultiplayer, workersSOs[workerSOId].workerName);

                workerIds.Add(workerSOId);

                coinsScript.AddCoins(-workersSOs[workerSOId].workerCost);
                generatorsStockScript.UpdateInStockGenerators(Id, generatorSOs.Length);
            }
        }

    }
    private IEnumerator Delay()
    {
         _dialoguePanel.SetActive(true);
         yield return new WaitForSeconds(_dialogueCloseTime);
         _dialoguePanel.SetActive(false);
    }


    private void ResourceLoader()
    {
        generatorSOs = Resources.LoadAll("SO/GeneratorSO", typeof(GeneratorSO))
            .Cast<GeneratorSO>()
            .ToArray();
        workersSOs = Resources.LoadAll("SO/WorkersSO", typeof(WorkersSO))
            .Cast<WorkersSO>()
            .ToArray();
    }

    public WorkersSO[] GetWorkersSOs() => workersSOs;
    public Transform[] GetWorkerRoots() => _workersRoots.Cast<Transform>().ToArray();
    public Worker[] GetCurrWorkers() => workers;

    public Transform[] GetGeneratorRoots() => generatorRoots;
    public GeneratorSO[] GetSOValues() => generatorSOs;

}
