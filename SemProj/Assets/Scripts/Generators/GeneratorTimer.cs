using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorTimer : MonoBehaviour
{
    private Image generatorTimer;

    private float currTime = 0;

    private Generator generatorScript;

    private void Start()
    {
        generatorTimer = GetComponent<Image>();
        generatorScript = GetComponentInParent<Generator>();
    }

    private void FixedUpdate()
    {
        if (currTime < generatorScript.timeToProduce)
        {
            currTime += Time.deltaTime;
            generatorTimer.fillAmount = currTime / generatorScript.timeToProduce;
        }
        else
        {
        generatorScript.isGeneratorFinished = true;
        }
    }

    public void Zeroing()
    {
        currTime = 0;
        generatorTimer.fillAmount = 0;
    }
}
