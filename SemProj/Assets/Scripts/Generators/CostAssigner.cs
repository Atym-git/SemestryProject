using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CostAssigner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] costTMPs;

    //[SerializeField] private TextMeshProUGUI[] workersCostTMPs;

    private GeneratorPlacer generatorPlacer;

    private void Start()
    {
        generatorPlacer = GetComponent<GeneratorPlacer>();
        AssignConstCosts();
    }

    private void AssignConstCosts()
    {
        var generatorsSOs = generatorPlacer.GetGeneratorsSO();
        var workersSOs = generatorPlacer.GetWorkersSOs();
        for (int i = 0; i < generatorsSOs.Length; i++)
        {
            costTMPs[i].text = generatorsSOs[i].generatorCost.ToString();
        }
        //Debug.Log($"{costTMPs}");
        for (int i = 0; i < workersSOs.Length; i++)
        {
            //Debug.Log($"TMPIndex: {i + generatorsSOs.Length}");
            costTMPs[i+generatorsSOs.Length].text = workersSOs[i].workerCost.ToString();
        }
    }

    public TextMeshProUGUI[] GetGeneratorsCostsTMP() => costTMPs;

}
