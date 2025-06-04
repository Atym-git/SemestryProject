using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GeneratorPlacer : MonoBehaviour
{
    [SerializeField, HideInInspector] private GameObject generatorPrefab;
    [SerializeField, HideInInspector] private GameObject _workerPrefab;

    [SerializeField] private Transform rootsParent;
    [SerializeField] private Transform[] generatorRoots;
    
    [SerializeField] private Transform _workersRootParent;
    [SerializeField] List<Transform> _workersRoots = new List<Transform>();

    private GeneratorSO[] generatorSOs;
    private WorkersSO[] workersSOs;
    private Worker[] workers;

    List<int> generatorIds = new List<int>();
    List<int> workerIds = new List<int>();

    [SerializeField] private GameObject _firstGenDial;

    [SerializeField] private int _idTrigger = 0;

    [SerializeField] private int _maxMultipleGeneratorAmount = 10;

    [SerializeField, HideInInspector] private CountNShowCoins coinsScript;

    private GeneratorsInStock generatorsStockScript;
    private Save save;
    [SerializeField] private Dialogues dialogues;

    private void Awake()
    {
        generatorsStockScript = GetComponent<GeneratorsInStock>();
        save = GetComponent<Save>();
        ResourceLoader();

        SetupRoots();
    }

    private void SetupRoots()
    {
        for (int i = 0; i < generatorSOs.Length; i++)
        {
            generatorRoots[i] = rootsParent.GetChild(i);
        }
        for (int i = 0; i < _workersRootParent.childCount; i++)
        {
            _workersRoots.Add(_workersRootParent.GetChild(i).transform);
        }
    }

    public void BuyGeneratorOrWorker(int Id)
    {
        if (Id < generatorSOs.Length)
        {
            if (coinsScript.IsEnoughToBuy(generatorSOs[Id].generatorCost) && Id < generatorSOs.Length &&
            !generatorIds.Contains(Id))
            {
                List<Transform> multipleGeneratorRoots;
                List<GameObject> instances;
                List<Generator> generators;
                SetupGenerators(Id, out multipleGeneratorRoots, out instances, out generators);

                generatorIds.Add(Id);
                coinsScript.AddCoins(-generatorSOs[Id].generatorCost);

                generatorsStockScript.UpdateInStockGenerators(Id, generatorSOs.Length);

                Dialogues(Id, generators);

                save.SaveGenerator(Id);
                ClearLists(multipleGeneratorRoots, instances, generators);
            }
        }
        else
        {
            int workerSOId = Id - generatorSOs.Length;
            if (coinsScript.IsEnoughToBuy(workersSOs[workerSOId].workerCost) && workerSOId < workersSOs.Length &&
            !workerIds.Contains(workerSOId))
            {
                SetupWorker(workerSOId);

                workerIds.Add(workerSOId);
                save.SaveWorkers(Id);

                coinsScript.AddCoins(-workersSOs[workerSOId].workerCost);
                generatorsStockScript.UpdateInStockGenerators(Id, generatorSOs.Length);
            }
        }

    }

    private void Dialogues(int Id, List<Generator> generators)
    {
        //Debug.Log("DialoguesInsidePlacer");

        if (Id == _idTrigger)
        {
            //Debug.Log("BoughtFirstGenerator");

            dialogues.ActivateSingleDialogue(_firstGenDial);

            dialogues.SetupGeneratorsDialogues(generators);
        }
    }

    private void ClearLists(List<Transform> multipleGeneratorRoots, List<GameObject> instances, List<Generator> generators)
    {
        multipleGeneratorRoots.Clear();
        instances.Clear();
        generators.Clear();
    }

    private void SetupGenerators(int Id, out List<Transform> multipleGeneratorRoots, out List<GameObject> instances, out List<Generator> generators)
    {
        multipleGeneratorRoots = new List<Transform>();
        instances = new List<GameObject>();
        generators = new List<Generator>();
        for (int i = 0; i < generatorRoots[Id].childCount; i++)
        {
            multipleGeneratorRoots.Add(generatorRoots[Id].GetChild(i));
            instances.Add(Instantiate(generatorPrefab, multipleGeneratorRoots[i]));
            generators.Add(instances[i].GetComponent<Generator>());
            generators[i].SetupGenerator(generatorSOs[Id].generatorSprite, generatorSOs[Id].timeConsume,
            generatorSOs[Id].coinsProducement, generatorSOs[Id].expProducement,
            generatorSOs[Id].generatorCost, generatorSOs[Id].generatorName, generatorSOs[Id].ScaleFactor);
        }
    }

    private void SetupWorker(int workerSOId)
    {
        GameObject instance = Instantiate(_workerPrefab, _workersRoots[workerSOId]);

        Worker worker = instance.GetComponent<Worker>();
        worker.SetupWorker(workersSOs[workerSOId].workerSprite, workersSOs[workerSOId].workerCost, workersSOs[workerSOId].coinsMultiplayer,
            workersSOs[workerSOId].XPMultiplayer, workersSOs[workerSOId].workerName, workersSOs[workerSOId].workerAnimation);
    }

    public void ClearIdLists()
    {
        generatorIds.Clear();
        workerIds.Clear();
    }


    private void ResourceLoader()
    {
        generatorSOs = Resources.LoadAll("SO/GeneratorSO", typeof(GeneratorSO))
            .Cast<GeneratorSO>()
            .ToArray();
        workersSOs = Resources.LoadAll("SO/WorkersSO", typeof(WorkersSO))
            .Cast<WorkersSO>()
            .ToArray();
        //Debug.Log(workersSOs.Length);

    }

    public WorkersSO[] GetWorkersSOs() => workersSOs;
    public Transform[] GetWorkerRoots() => _workersRoots.Cast<Transform>().ToArray();
    public Worker[] GetCurrWorkers() => workers;

    public Transform[] GetGeneratorRoots() => generatorRoots;
    public GeneratorSO[] GetGeneratorsSO() => generatorSOs;

}
