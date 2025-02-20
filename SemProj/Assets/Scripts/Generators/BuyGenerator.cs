using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuyGenerator : MonoBehaviour
{

    [SerializeField, HideInInspector] private GameObject generatorPrefab;

    [SerializeField] private Transform[] generatorRoot;

    private GeneratorSO[] generatorSOs;

    List<int> generatorIds = new List<int>();

    [SerializeField, HideInInspector] private CountNShowCoins coinsScript;

    private void Start()
    {
        ResourceLoader();
    }

    public void OnGeneratorBought(int generatorId)
    {
        if (coinsScript.currCoins >= generatorSOs[generatorId].generatorCost && generatorId < generatorSOs.Length &&
            !generatorIds.Contains(generatorId))
        {

            GameObject instance = Instantiate(generatorPrefab, generatorRoot[generatorId]);

            Generator generator = instance.GetComponent<Generator>();

            generator.SetupGenerator(generatorSOs[generatorId].generatorSprite, generatorSOs[generatorId].timeConsume,
                generatorSOs[generatorId].coinsProducement, generatorSOs[generatorId].expProducement,
                generatorSOs[generatorId].generatorCost,generatorSOs[generatorId].ScaleFactor);
            generatorIds.Add(generatorId);
            coinsScript.AddCoins(-generatorSOs[generatorId].generatorCost);
        }

    }


    private void ResourceLoader()
    {
        generatorSOs = Resources.LoadAll("GeneratorSO", typeof(GeneratorSO))
            .Cast<GeneratorSO>()
            .ToArray();
    }
}
