using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class LMBClicker : MonoBehaviour
{
    public float coinsPerLMB;

    [SerializeField, HideInInspector] private CountNShowCoins coinsScript;

    public void OnPlayerClick()
    {
        coinsScript.AddCoins(coinsPerLMB);
    }
}
