using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IsCursorOnShop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private CameraZoom cameraZoom;

    public void OnPointerEnter(PointerEventData eventData)
    {
        cameraZoom.isCursorOnShop = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cameraZoom.isCursorOnShop = false;
    }
}
