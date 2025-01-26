using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(CountNShowExp))]
[RequireComponent(typeof(CountNShowCoins))]
public class Generator : MonoBehaviour
{
    public float timeToProduce;
    public float amountOfCoinsProducing;
    public float amountOfExpProducing;

    [SerializeField, HideInInspector] private CountNShowExp expScript;
    [SerializeField, HideInInspector] private CountNShowCoins coinsScript;

    private void Start()
    {
        expScript.gameObject.GetComponent<CountNShowExp>();
        coinsScript.gameObject.GetComponent<CountNShowCoins>();
        StartCoroutine(Produce());
    }

    private IEnumerator Produce()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToProduce);
            expScript.AddExp(amountOfExpProducing);
            coinsScript.AddCoins(amountOfCoinsProducing);
        }
    }
}