using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ShowBuyCost : MonoBehaviour
{
    [SerializeField] private int[] generatorsCost;

    [SerializeField] private TextMeshProUGUI[] generatorsCostTMP;

    private void Start()
    {
        ShowConstCosts();
    }

    private void ShowConstCosts()
    {
        for (int i = 0; i < generatorsCost.Length; i++)
        {
            generatorsCostTMP[i].text = generatorsCost[i].ToString();
        }
    }

}
