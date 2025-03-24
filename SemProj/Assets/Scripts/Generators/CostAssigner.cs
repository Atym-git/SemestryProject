using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CostAssigner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] generatorsCostTMPs;

    [SerializeField] private TextMeshProUGUI[] workersCostTMPs;

    private GeneratorPlacer generatorPlacer;
    private WorkerPlacer workerPlacer;

    private void Start()
    {
        generatorPlacer = GetComponent<GeneratorPlacer>();
        workerPlacer = GetComponent<WorkerPlacer>();
        AssignConstCosts();
    }

    private void AssignConstCosts()
    {
        for (int i = 0; i < generatorPlacer.GetSOValues().Length; i++)
        {
            generatorsCostTMPs[i].text = generatorPlacer.GetSOValues()[i].generatorCost.ToString();
        }
        for (int i = 0; i < workersCostTMPs.Length; i++)
        {
            workersCostTMPs[i].text = workerPlacer.GetWorkersSOs()[i].workerCost.ToString();
        }
    }

    public TextMeshProUGUI[] GetGeneratorsCostsTMP() => generatorsCostTMPs;

}
