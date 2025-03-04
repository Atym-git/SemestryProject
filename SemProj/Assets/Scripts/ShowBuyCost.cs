using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ShowBuyCost : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] generatorsCostTMP;

    private GeneratorPlacer generatorPlacer;

    private void Start()
    {
        generatorPlacer = GetComponent<GeneratorPlacer>();
        ShowConstCosts();
    }

    private void ShowConstCosts()
    {
        for (int i = 0; i < generatorPlacer.GetSOValues().Length; i++)
        {
            generatorsCostTMP[i].text = generatorPlacer.GetSOValues()[i].generatorCost.ToString();
        }
    }

}
