using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuyGenerator : MonoBehaviour
{

    [SerializeField] private GameObject generatorPrefab;

    [SerializeField] private Transform generatorRoot;

    private GeneratorSO[] generatorSOs;

    private int generatorIndex = 0;

    [SerializeField] private CountNShowCoins coinsScript;

    private void Start()
    {
        ResourceLoader();
    }

    public void OnGeneratorBought()
    {
        if (coinsScript.currCoins >= generatorSOs[generatorIndex].generatorCost && generatorIndex < generatorSOs.Length)
        {

            GameObject instance = Instantiate(generatorPrefab, generatorRoot);

            Generator generator = instance.GetComponent<Generator>();

            generator.SetupGenerator(generatorSOs[generatorIndex].generatorSprite, generatorSOs[generatorIndex].timeConsume,
                generatorSOs[generatorIndex].coinsProducement, generatorSOs[generatorIndex].expProducement, generatorSOs[generatorIndex].generatorCost);
            coinsScript.AddCoins(-generatorSOs[generatorIndex].generatorCost);
            generatorIndex++;
        }
            
    }


    private void ResourceLoader()
    {
        generatorSOs = Resources.LoadAll("GeneratorSO", typeof(GeneratorSO))
            .Cast<GeneratorSO>()
            .ToArray();
    }
}
