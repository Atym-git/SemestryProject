using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorTimer : MonoBehaviour
{
    private Image generatorTimer;

    private float currTime = 0;

    private Generator generatorScript;
    private Dialogues dialogues;

    private GameObject genDoneDial;
    private bool _genDoneDialOut = false;

    private void Start()
    {
        generatorTimer = GetComponent<Image>();
        generatorScript = GetComponentInParent<Generator>();
    }

    private void FixedUpdate()
    {
        Timer();
    }

    private void Timer()
    {
        if (currTime < generatorScript.timeToProduce)
        {
            currTime += Time.deltaTime;
            generatorTimer.fillAmount = currTime / generatorScript.timeToProduce;
        }
        else
        {
            generatorScript.isGeneratorFinished = true;
            Dialogues();
        }
    }

    private void Dialogues()
    {
        if (dialogues != null && genDoneDial != null && !_genDoneDialOut)
        {
            dialogues.ActivateSingleDialogue(genDoneDial);
            _genDoneDialOut = true;
        }
    }

    public void GenDoneDial(Dialogues Dialogues, GameObject GenDoneDial)
    {
        dialogues = Dialogues;
        genDoneDial = GenDoneDial;
    }

    public void Zeroing()
    {
        generatorTimer = GetComponent<Image>();
        currTime = 0;
        generatorTimer.fillAmount = 0;
    }
    public float GetRemainingTime() => generatorScript.timeToProduce - currTime;
}
