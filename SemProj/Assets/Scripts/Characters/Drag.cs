using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Transform _startParent;

    [SerializeField] private Canvas canvas;

    [SerializeField] private float dragDivideY = 4.125f;
    [SerializeField] private float dragDivideX = 6f;

    private Worker setupScript;
        
    private void Start()
    {
        _startParent = transform.parent;
        Debug.Log(_startParent);
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        setupScript = GetComponent<Worker>();
        canvas = GetComponentInParent<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

        if (transform.parent != _startParent)
        {
            Debug.Log(1);
            setupScript.WorkerOff();
        }
        transform.parent = _startParent;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 deltaVector = new Vector2(eventData.delta.x / dragDivideX, eventData.delta.y / dragDivideY);
        rectTransform.anchoredPosition += deltaVector;
        //var screenPos = Camera.main.WorldToScreenPoint(transform.position) / canvas.scaleFactor;
        //float height = Screen.height;
        //float width = Screen.width;
        //float x = screenPos.x - (width / 2);
        //float y = screenPos.y - (height / 2);
        //rectTransform.anchoredPosition = new Vector2(x, y);
        //rectTransform.anchoredPosition = screenPos / 100;
        //rectTransform.anchoredPosition = eventData.worldPosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
}