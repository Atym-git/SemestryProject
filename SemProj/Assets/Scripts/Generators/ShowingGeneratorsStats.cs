using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowingGeneratorsStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameTMP;
    [SerializeField] private TextMeshProUGUI coinsProducTMP;
    [SerializeField] private TextMeshProUGUI expProducTMP;
    [SerializeField] private TextMeshProUGUI remainingTimeTMP;
    [SerializeField] private Image generatorRenderer;

    private Transform[] generatorRoots;
    private Transform[] workerRoots;

    private WorkersSO[] workers;

    private GeneratorTimer generatorTimer;
    private GeneratorPlacer generatorPlacer;

    private int _generatorMaxId;

    private bool _isShowing = false;

    private void Start()
    {
        generatorPlacer = GetComponent<GeneratorPlacer>();
        generatorRoots = generatorPlacer.GetGeneratorRoots();
        workerRoots = generatorPlacer.GetWorkerRoots();

        _generatorMaxId = generatorRoots.Length;
    }

    public void ShowGeneratorStats(int generatorId)
    {
        _isShowing = true;
        Generator generator = generatorRoots[generatorId].GetComponentInChildren<Generator>();
        nameTMP.text = generator.name;
        generatorRenderer.sprite = generator.generatorSprite;
        coinsProducTMP.text = generator.coinsProducement.ToString();
        expProducTMP.text = generator.expProducement.ToString();
        generatorTimer = generator.GetComponentInChildren<GeneratorTimer>();
        StartCoroutine(ShowTimeInSecs());
    }
    public void ShowWorkerStats(int workerId)
    {
        //Worker worker = workerRoots[workerId - _generatorMaxId].GetComponentInChildren<Worker>();
        //Debug.Log(workerRoots.Length);
        //Debug.Log(workerId - _generatorMaxId);
        workers = generatorPlacer.GetWorkersSOs();
        WorkersSO worker = workers[workerId - _generatorMaxId];
        Debug.Log(worker);
        nameTMP.text = worker.workerName;
        generatorRenderer.sprite = worker.workerSprite;
        coinsProducTMP.text = worker.coinsMultiplayer.ToString();
        expProducTMP.text = worker.XPMultiplayer.ToString();
        remainingTimeTMP.text = "";
    }


    private IEnumerator ShowTimeInSecs()
    {
        while (_isShowing)
        {
            remainingTimeTMP.text = Mathf.Round(generatorTimer.GetRemainingTime()).ToString();
            yield return new WaitForSeconds(1);
        }
    }

    public void StopShowing()
    {
        _isShowing = false;
    }
}
