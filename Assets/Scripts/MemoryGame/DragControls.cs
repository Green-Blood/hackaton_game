using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragControls : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    private Vector3 startingPos;
    private Vector3 lastPos;
    

    public void Start()
    {
        startingPos = transform.position;
    }

    private void Update()
    {
       
    }

    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out position);

        Quaternion.LookRotation(Vector3.forward, position);

        transform.position = canvas.transform.TransformPoint(position);
    }

    public void ResetPosition()
    {
        transform.position = startingPos;
    }
}
