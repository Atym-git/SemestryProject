using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorsInStock : MonoBehaviour
{
    [SerializeField] private GameObject[] optionMarks;

    [SerializeField] private GameObject[] upgradeButtons;

    [SerializeField] private Sprite[] generatorInStockSprites;

    [SerializeField] private Image[] generatorsImages;

    private TextMeshProUGUI[] generatorsCostTMP;

    private void Start()
    {
        //for (int i = 0; i < generatorsImages.Length; i++)
        //{
        //    optionMarks[i] = generatorsImages[i].transform.GetChild(1).GetComponent<GameObject>();
        //}
        //for (int i = 0; i < generatorsImages.Length; i++)
        //{
        //    upgradeButtons[i] = generatorsImages[i].transform.GetChild(2).GetComponent<GameObject>();
        //}
        CostAssigner costAssignerScript = GetComponent<CostAssigner>();
        generatorsCostTMP = costAssignerScript.GetGeneratorsCostsTMP();
    }

    public void UpdateInStockGenerators(int generatorId)
    {
        Destroy(generatorsCostTMP[generatorId]);
        optionMarks[generatorId].SetActive(true);
        upgradeButtons[generatorId].SetActive(true);
        generatorsImages[generatorId].sprite = generatorInStockSprites[generatorId];
    }
}
