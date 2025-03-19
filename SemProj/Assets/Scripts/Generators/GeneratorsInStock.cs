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
