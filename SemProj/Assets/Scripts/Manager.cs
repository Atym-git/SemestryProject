using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private ExpGain _expScript;
    [SerializeField] private CountNShowCoins _coinsScript;

    public static ExpGain expScript { get; private set; }
    public static CountNShowCoins coinsScript { get; private set; }

    private void Awake()
    {
        expScript = _expScript;
        coinsScript = _coinsScript;
    }

}
