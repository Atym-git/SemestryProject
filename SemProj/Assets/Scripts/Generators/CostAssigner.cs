using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CostAssigner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] generatorsCostTMP;

    private GeneratorPlacer generatorPlacer;

    private void Start()
    {
        generatorPlacer = GetComponent<GeneratorPlacer>();
        AssignConstCosts();
    }

    private void AssignConstCosts()
    {
        for (int i = 0; i < generatorPlacer.GetSOValues().Length; i++)
        {
            generatorsCostTMP[i].text = generatorPlacer.GetSOValues()[i].generatorCost.ToString();
        }
    }

    public TextMeshProUGUI[] GetGeneratorsCostsTMP() => generatorsCostTMP;

}
