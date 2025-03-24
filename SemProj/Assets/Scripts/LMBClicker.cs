using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;

public class LMBClicker : MonoBehaviour, IPointerClickHandler
{
    public float coinsPerLMB;

    [SerializeField] private CountNShowCoins coinsScript;

    public void OnPointerClick(PointerEventData eventData)
    {
            coinsScript.AddCoins(coinsPerLMB);
    }
}
