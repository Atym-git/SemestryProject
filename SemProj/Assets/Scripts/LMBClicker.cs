using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;

public class LMBClicker : MonoBehaviour, IPointerClickHandler
{
    public float coinsPerLMB;

    [SerializeField] private CountNShowCoins coinsScript;

    [SerializeField] private AudioClip clickClip;
    [SerializeField] private float clickVolume = 0.05f;

    [SerializeField] private GameObject animationGameObject;

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundFXManager.SFXinstance.PlaySoundFXClip(clickClip, transform, clickVolume);
        //Vector3 mousePos = Input.mousePosition;
        //Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);
        Instantiate(animationGameObject, eventData.pressPosition, Quaternion.identity);
        coinsScript.AddCoins(coinsPerLMB);
    }
}
