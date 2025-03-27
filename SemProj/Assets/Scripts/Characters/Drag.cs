using UnityEngine;
using UnityEngine.EventSystems;

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
        canvas = GetComponentInParent<Canvas>();
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
        rectTransform.anchoredPosition += eventData.delta / 6f;
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
        Debug.Log("endDrag");
    }
}