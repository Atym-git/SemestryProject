using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LMBClicker : MonoBehaviour
{
    public float coinsPerLMB;

    [SerializeField] private Button _clickerBut;
    [SerializeField] private CountNShowCoins coinsScript;

    [SerializeField] private AudioClip clickClip;
    [SerializeField] private float clickVolume = 0.05f;

    [SerializeField] private GameObject animationGameObject;

    private void Start()
    {
        //_clickerBut.onClick.AddListener(Clicker);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);
            if (mousePos.x < 1210)
            {
                Clicker();
            }
        }
    }

    private void Clicker()
    {
        SoundFXManager.SFXinstance.PlaySoundFXClip(clickClip, transform, clickVolume);
        coinsScript.AddCoins(coinsPerLMB);
        Debug.Log(1);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
    SoundFXManager.SFXinstance.PlaySoundFXClip(clickClip, transform, clickVolume);
    //Vector3 mousePos = Input.mousePosition;
    //Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);
    //Instantiate(animationGameObject, eventData.pressPosition, Quaternion.identity);
    coinsScript.AddCoins(coinsPerLMB);
    }
}
