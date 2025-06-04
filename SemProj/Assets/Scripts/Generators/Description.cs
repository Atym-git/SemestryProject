using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Description : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameTMP;
    [SerializeField] private TextMeshProUGUI generatorCoinsProducTMP;
    [SerializeField] private TextMeshProUGUI generatorExpProducTMP;
    [SerializeField] private TextMeshProUGUI generatorRemainTimeTMP;
    [SerializeField] private Image generatorRenderer;
    
    [SerializeField] private TextMeshProUGUI workerCoinsBuffTMP;
    [SerializeField] private TextMeshProUGUI workerExpBuffTMP;
    [SerializeField] private Image workerRenderer;

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
        nameTMP.text = generator.generatorName;
        generatorRenderer.sprite = generator.generatorSprite;
        generatorCoinsProducTMP.text = generator.coinsProducement.ToString();
        generatorExpProducTMP.text = generator.expProducement.ToString();
        generatorTimer = generator.GetComponentInChildren<GeneratorTimer>();
        Debug.Log(nameTMP.text);
        StartCoroutine(ShowTimeInSecs());
    }
    public void ShowWorkerStats(int workerId)
    {
        //Worker worker = workerRoots[workerId - _generatorMaxId].GetComponentInChildren<Worker>();
        //Debug.Log(workerRoots.Length);
        //Debug.Log(workerId - _generatorMaxId);
        workers = generatorPlacer.GetWorkersSOs();
        WorkersSO worker = workers[workerId - _generatorMaxId];
        nameTMP.text = worker.workerName;
        workerRenderer.sprite = worker.workerDescPic;
        workerCoinsBuffTMP.text = worker.coinsMultiplayer.ToString();
        workerExpBuffTMP.text = worker.XPMultiplayer.ToString();
    }

    private IEnumerator ShowTimeInSecs()
    {
        while (_isShowing)
        {
            generatorRemainTimeTMP.text = Mathf.RoundToInt(generatorTimer.GetRemainingTime()).ToString();
            yield return new WaitForSeconds(1);
        }
    }

    public void StopShowing()
    {
        _isShowing = false;
        StopCoroutine(ShowTimeInSecs());
        nameTMP.text = "EQUIPMENT SHOP";
    }
}
