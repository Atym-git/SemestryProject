using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneratorPlacer : MonoBehaviour
{

    [SerializeField, HideInInspector] private GameObject generatorPrefab;

    [SerializeField] private Transform rootsParent;
    [SerializeField] private Transform[] generatorRoots;

    [SerializeField] private GeneratorSO[] generatorSOs;

    List<int> generatorIds = new List<int>();

    [SerializeField] private GameObject _dialoguePanel;

    private const int _idTrigger = 0;

    [SerializeField] private int _dialogueCloseTime = 8;

    [SerializeField, HideInInspector] private CountNShowCoins coinsScript;

    private GeneratorsInStock generatorsStockScript;

    private void Awake()
    {
        generatorsStockScript = GetComponent<GeneratorsInStock>();
        ResourceLoader();
        
        for (int i = 0; i < rootsParent.childCount; i++)
        {
            generatorRoots[i] = rootsParent.GetChild(i);
        }
    }

    public void BuyGenerator(int generatorId)
    {
        if (coinsScript.IsEnoughToBuy(generatorSOs[generatorId].generatorCost) && generatorId < generatorSOs.Length &&
            !generatorIds.Contains(generatorId))
        {
            GameObject instance = Instantiate(generatorPrefab, generatorRoots[generatorId]);

            Generator generator = instance.GetComponent<Generator>();

            generator.SetupGenerator(generatorSOs[generatorId].generatorSprite, generatorSOs[generatorId].timeConsume,
                generatorSOs[generatorId].coinsProducement, generatorSOs[generatorId].expProducement,
                generatorSOs[generatorId].generatorCost, generatorSOs[generatorId].ScaleFactor);

            generatorIds.Add(generatorId);
            coinsScript.AddCoins(-generatorSOs[generatorId].generatorCost);

            generatorsStockScript.UpdateInStockGenerators(generatorId);
            if (generatorId == _idTrigger)
            {
                StartCoroutine(Delay());
            }
        }
    }
    private IEnumerator Delay()
    {
         _dialoguePanel.SetActive(true);
         yield return new WaitForSeconds(_dialogueCloseTime);
         _dialoguePanel.SetActive(false);
    }


    private void ResourceLoader()
    {
        generatorSOs = Resources.LoadAll("SO/GeneratorSO", typeof(GeneratorSO))
            .Cast<GeneratorSO>()
            .ToArray();
    }

    public Transform[] GetGeneratorRoots() => generatorRoots;
    public GeneratorSO[] GetSOValues() => generatorSOs;

}
