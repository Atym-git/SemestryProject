using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorsInStock : MonoBehaviour
{
    [SerializeField] private GameObject[] optionMarks;

    [SerializeField] private GameObject[] upgradeButtons;

    [SerializeField] private GameObject[] generatorButtons;

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

    public void UpdateInStockGenerators(int currId, int generatorsMaxAmount)
    {
        int generatorsMaxId = generatorsMaxAmount - 1;
        if (currId < generatorsMaxId)
        {
            upgradeButtons[currId].SetActive(true);
            //generatorButtons[currId].SetActive(true);
        }
        Destroy(generatorsCostTMP[currId]);
        optionMarks[currId].SetActive(true);
        generatorsImages[currId].sprite = generatorInStockSprites[currId];
    }
}
