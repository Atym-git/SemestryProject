using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleToneManager : MonoBehaviour
{
    [SerializeField, HideInInspector] private ExpGain _expScript;
    [SerializeField, HideInInspector] private CountNShowCoins _coinsScript;

    public static ExpGain expScript { get; private set; }
    public static CountNShowCoins coinsScript { get; private set; }

    private void Awake()
    {
        expScript = _expScript;
        coinsScript = _coinsScript;
    }

}
