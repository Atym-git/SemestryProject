using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(LevelUp))]
//[RequireComponent(typeof(CountNShowCoins))]
public class Generator : MonoBehaviour
{
    public float timeToProduce;
    public float coinsProducement;
    public float expProducement;
    public float generatorCost;

    //public float timeToProduceATick;
    //public float CoinsProducingPerTick;
    //public float ExpProducingPerTick;

    //private float timeToProduce = 120;
    //private float currProduceTime = 0;
    //private float coinsProducement;
    //private float expProducement;

    public bool isGeneratorFinished = false;

    [SerializeField] private ExpGain expScript;
    [SerializeField] private CountNShowCoins coinsScript;
    private GeneratorTimer generatorTimerScript;

    private void Start()
    {
        expScript = Manager.expScript;
        coinsScript = Manager.coinsScript;
        generatorTimerScript = GetComponentInChildren<GeneratorTimer>();
    }

    public void SetupGenerator(Sprite GeneratorSprite, float TimeToProduce, float CoinsProducement, float ExpProducement, float GeneratorCost)
    {
        GetComponent<Image>().sprite = GeneratorSprite;
        timeToProduce = TimeToProduce;
        coinsProducement = CoinsProducement;
        expProducement = ExpProducement;
        generatorCost = GeneratorCost;
    }

    //private IEnumerator Produce()
    //{
    //    //if (currProduceTime < timeToProduce)
    //    //{
    //    //    Debug.Log(currProduceTime);
    //    //    currProduceTime += Time.deltaTime;
    //    //}
    //    Debug.Log("Start");
    //    yield return new WaitForSeconds(timeToProduce);
    //    Debug.Log("End");
    //    isGeneratorFinished = true;
    //    transform.GetChild(0).gameObject.SetActive(true);
        
    //}

    public void OnGeneratorClicked()
    {
        if (isGeneratorFinished)
        {
            expScript.OnExpGain(expProducement);
            coinsScript.AddCoins(coinsProducement);
            isGeneratorFinished = false;
            generatorTimerScript.Zeroing();
        }
    }
}