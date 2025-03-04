using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorPlacer : MonoBehaviour
{

    [SerializeField, HideInInspector] private GameObject generatorPrefab;

    [SerializeField] private Transform[] generatorRoot;

    private GeneratorSO[] generatorSOs;

    List<int> generatorIds = new List<int>();

    [SerializeField] private Image _dialogueWindow;

    private const int _idTrigger = 0;

    private const int _dialogueCloseTime = 8;

    [SerializeField, HideInInspector] private CountNShowCoins coinsScript;

    private void Awake()
    {
        ResourceLoader();
    }

    public void BuyGenerator(int generatorId)
    {
        if (coinsScript.IsEnoughToBuy(generatorSOs[generatorId].generatorCost) && generatorId < generatorSOs.Length &&
            !generatorIds.Contains(generatorId))
        {
            GameObject instance = Instantiate(generatorPrefab, generatorRoot[generatorId]);

            Generator generator = instance.GetComponent<Generator>();

            generator.SetupGenerator(generatorSOs[generatorId].generatorSprite, generatorSOs[generatorId].timeConsume,
                generatorSOs[generatorId].coinsProducement, generatorSOs[generatorId].expProducement,
                generatorSOs[generatorId].generatorCost, generatorSOs[generatorId].ScaleFactor);
            generatorIds.Add(generatorId);
            coinsScript.AddCoins(-generatorSOs[generatorId].generatorCost);
            if (generatorIds.Contains(_idTrigger))
            {
                _dialogueWindow.gameObject.SetActive(true);
                StartCoroutine(Delay());
                _dialogueWindow.gameObject.SetActive(false);
            }
        }

    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(_dialogueCloseTime);
        StopCoroutine(Delay());
    }


    private void ResourceLoader()
    {
        generatorSOs = Resources.LoadAll("SO/GeneratorSO", typeof(GeneratorSO))
            .Cast<GeneratorSO>()
            .ToArray();
    }

    public GeneratorSO[] GetSOValues() => generatorSOs;

}
