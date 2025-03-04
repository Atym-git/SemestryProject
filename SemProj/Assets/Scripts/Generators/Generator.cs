using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    public float timeToProduce;
    public float coinsProducement;
    public float expProducement;
    public float generatorCost;

    private const int firstChild = 0;
    private const int secondChild = 1;

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

    private void Start()
    {
        expScript = Manager.expScript;
        coinsScript = Manager.coinsScript;
        generatorTimerScript = transform.GetChild(firstChild).GetComponent<GeneratorTimer>();
        expAnimator = transform.GetChild(secondChild).GetComponent<Animator>();
    }

    public void SetupGenerator(Sprite GeneratorSprite, float TimeToProduce, float CoinsProducement, float ExpProducement, float GeneratorCost, float ScaleFactor)
    {
        GetComponent<Image>().sprite = GeneratorSprite;
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