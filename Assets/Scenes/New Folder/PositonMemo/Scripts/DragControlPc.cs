using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DragControlPc : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    public void DragHandler(BaseEventData data)
    {

        Debug.Log("Diocane");
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out position);
        transform.position = canvas.transform.TransformPoint(position);
    }
}
