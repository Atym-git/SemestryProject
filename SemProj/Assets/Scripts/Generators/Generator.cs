using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    private Sprite generatorSprite;

    public float timeToProduce;
    public float coinsProducement;
    public float expProducement;
    public float generatorCost;

    //private int[] childs = { 0, 1 };


    //public float timeToProduceATick;
    //public float CoinsProducingPerTick;
    //public float ExpProducingPerTick;

    //private float timeToProduce = 120;
    //private float currProduceTime = 0;
    //private float coinsProducement;
    //private float expProducement;

    public bool isGeneratorFinished = false;

    private Animator expAnimator;

    private const string animatiorBool = "RunExpAnim";

    private ExpGain expScript;
    private CountNShowCoins coinsScript;
    private GeneratorTimer generatorTimerScript;
    private GetGeneratorStats generatorStatsScript;

    private void Start()
    {
        expScript = Manager.expScript;
        coinsScript = Manager.coinsScript;
        for (int i = 0; i < transform.childCount; i++)
        {
            generatorTimerScript = transform.GetChild(i).GetComponent<GeneratorTimer>();
            expAnimator = transform.GetChild(i).GetComponent<Animator>();
        }
    }

    public void SetupGenerator(Sprite GeneratorSprite, float TimeToProduce, float CoinsProducement, float ExpProducement, float GeneratorCost, float ScaleFactor)
    {
        generatorSprite = GeneratorSprite;
        GetComponent<Image>().sprite = generatorSprite;
        timeToProduce = TimeToProduce;
        coinsProducement = CoinsProducement;
        expProducement = ExpProducement;
        generatorCost = GeneratorCost;
        GetComponent<RectTransform>().localScale *= ScaleFactor;
        gameObject.GetComponentInChildren<RectTransform>().localScale *= 4;
        GetComponent<RectTransform>().localScale /= 4;
    }

    public void WorkerOnGenerator(float coinsMultiplier, float expMultiplier)
    {
        coinsProducement *= coinsMultiplier;
        expProducement *= expMultiplier;
    }
    public void WorkerOffGenerator(float coinsMultiplier, float expMultiplier)
    {
        coinsProducement /= coinsMultiplier;
        expProducement /= expMultiplier;
    }

    public void UpgradeGenerator(float coinsUpg, float expUpg, float cdUpg)
    {
        coinsProducement += coinsUpg;
        expProducement += expUpg;
        timeToProduce += cdUpg;
        generatorStatsScript.GetStats(generatorSprite, coinsProducement, expProducement, timeToProduce);
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
            expAnimator.Play("Exp");
            expScript.OnExpGain(expProducement);
            coinsScript.AddCoins(coinsProducement);
            isGeneratorFinished = false;
            generatorTimerScript.Zeroing();
        }
    }
}