using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    public string generatorName;

    public Sprite generatorSprite;

    public float generatorCost;

    public float timeToProduce;
    public float coinsProducement;
    public float expProducement;
    
    public bool isMultiple = false;

    public int generatorLevel = 1;

    private int generatorTimerChild = 0;
    private int animatorManagerChild = 1;

    public bool isGeneratorFinished = false;

    private Animator expAnimator;

    private const string animatiorBool = "RunExpAnim";

    private ExpGain expScript;
    private CountNShowCoins coinsScript;
    private GeneratorTimer generatorTimerScript;

    private Image generatorImage;
    private RectTransform generatorRectTransform;

    //private Transform[] generatorsTimers;

    private void Awake()
    {
        expScript = SingleToneManager.expScript;
        coinsScript = SingleToneManager.coinsScript;
        generatorImage = GetComponent<Image>();
        generatorRectTransform = GetComponent<RectTransform>();
        generatorTimerScript = transform.GetChild(generatorTimerChild).GetComponent<GeneratorTimer>();
        expAnimator = transform.GetChild(animatorManagerChild).GetComponent<Animator>();
    }

    private void Start()
    {
        //for (int i = 0; i < transform.parent.childCount; i++)
        //{
        //    transform.GetChild(i).gameObject.SetActive(true);
        //}
        if (transform.parent.parent.GetComponent<Image>()) //That means generator spawned in a singe-slot transform
        {
            isMultiple = true;
        }
    }

    public void SetupGenerator(Sprite GeneratorSprite, float TimeToProduce, float CoinsProducement, float ExpProducement,
        float GeneratorCost, float ScaleFactor, int GeneratorAmount)
    {
        generatorImage = GetComponent<Image>();
        Debug.Log(generatorImage);

        generatorSprite = GeneratorSprite;
        generatorImage.sprite = generatorSprite;
        timeToProduce = TimeToProduce;
        coinsProducement = CoinsProducement;
        expProducement = ExpProducement;
        generatorCost = GeneratorCost;
        //isMultiple = GeneratorAmount;
        //generatorRectTransform.localScale *= ScaleFactor;
        //gameObject.GetComponentInChildren<RectTransform>().localScale *= 4;
        //generatorRectTransform.localScale /= 4;
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

    public void UpgradeGenerator(Sprite nextLevelSprite, float coinsUpg, float expUpg, float cdUpg)
    {
        if (nextLevelSprite != null)
        {
            generatorImage.sprite = nextLevelSprite;
        }
        generatorLevel++;
        coinsProducement *= coinsUpg;
        expProducement *= expUpg;
        timeToProduce *= cdUpg;
    }

    public void OnGeneratorClicked()
    {
        if (isGeneratorFinished)
        {
            expAnimator.Play("Exp");
            expScript.GainExp(expProducement);
            coinsScript.AddCoins(coinsProducement);
            isGeneratorFinished = false;
            if (isMultiple)
            {
                Transform rootsParent = transform.parent.parent;
                List<Transform> generatorsTimersObjects = new List<Transform>();
                List<GeneratorTimer> generatorsTimers = new List<GeneratorTimer>();

                for (int i = 0; i < rootsParent.childCount; i++)
                {
                    generatorsTimersObjects.Add(rootsParent.GetChild(i).GetChild(0).GetChild(generatorTimerChild));
                    //generatorsTimers[i] = rootsParent.GetChild(i).GetChild(0).GetChild(generatorTimer);
                }
                foreach (Transform t in generatorsTimersObjects)
                {
                    generatorsTimers.Add(t.GetComponent<GeneratorTimer>());
                }
                foreach (GeneratorTimer genTim in generatorsTimers)
                {
                    genTim.Zeroing();
                }
            }
            generatorTimerScript.Zeroing();
        }
    }
}