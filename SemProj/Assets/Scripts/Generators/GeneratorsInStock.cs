using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorsInStock : MonoBehaviour
{
    [SerializeField] private GameObject[] OptionMarks;

    [SerializeField] private Sprite[] generatorInStockSprites;

    [SerializeField] private Image[] generatorsImages;

    private TextMeshProUGUI[] generatorsCostTMP;

    private void Start()
    {
        CostAssigner costAssignerScript = GetComponent<CostAssigner>();
        generatorsCostTMP = costAssignerScript.GetGeneratorsCostsTMP();
    }

    public void UpdateInStockGenerators(int generatorId)
    {
        Destroy(generatorsCostTMP[generatorId]);
        OptionMarks[generatorId].SetActive(true);
        generatorsImages[generatorId].sprite = generatorInStockSprites[generatorId];
    }
}
