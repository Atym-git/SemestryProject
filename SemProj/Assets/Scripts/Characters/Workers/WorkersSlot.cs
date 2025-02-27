using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorkersSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().position =
                GetComponent<RectTransform>().position;
            eventData.pointerDrag.transform.SetParent(transform);
            Worker setupWorkers = eventData.pointerDrag.GetComponent<Worker>();
            setupWorkers.WorkerSet();
        }
    }
}
