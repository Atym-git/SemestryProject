using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

//[RequireComponent(typeof(LevelUp))]
//[RequireComponent(typeof(CountNShowCoins))]
public class Generator : MonoBehaviour
{
    public float timeToProduce;
    public float amountOfCoinsProducing;
    public float amountOfExpProducing;

    [SerializeField, HideInInspector] private ExpGain expScript;
    [SerializeField, HideInInspector] private CountNShowCoins coinsScript;

    private void Start()
    {
        //expScript.gameObject.GetComponent<LevelUp>();
        //coinsScript.gameObject.GetComponent<CountNShowCoins>();
        StartCoroutine(Produce());
    }

    private IEnumerator Produce()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToProduce);
            expScript.OnExpGain(amountOfExpProducing);
            coinsScript.AddCoins(amountOfCoinsProducing);
        }
    }
}