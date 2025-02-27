using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Transform _startParent;

    [SerializeField] private Canvas canvas;

    private Worker setupScript;
        
    private void Start()
    {
        _startParent = transform.parent;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        setupScript = GetComponent<Worker>();
        canvas = FindObjectOfType<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (transform.parent != _startParent)
        {
            setupScript.WorkerOff();
        }
        transform.parent = _startParent;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        Debug.Log("BeginDrag");
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        Debug.Log("endDrag");
    }
}