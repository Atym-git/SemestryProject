using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CountNShowExp))]
public class ExpTimer : MonoBehaviour
{
    [SerializeField] private float timeForTimer;
    [SerializeField] private float expGain;
    [field: SerializeField, HideInInspector] private Image expTimer;
    [SerializeField, HideInInspector] private TextMeshProUGUI ShowExp;
    private float currTime = 0;

    [SerializeField, HideInInspector] private CountNShowExp expScript;

    private void Start()
    {
        ShowExp.text = currTime.ToString();
        expScript.gameObject.GetComponent<CountNShowExp>();
    }

    void FixedUpdate()
    {
        currTime += Time.deltaTime;
        expTimer.fillAmount = currTime / timeForTimer;
        if (currTime >= timeForTimer)
        {
            currTime = 0;
            expTimer.fillAmount = 0;
            expScript.AddExp(expGain);
        }
    }
}