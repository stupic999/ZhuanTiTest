using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStickController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    public Image Bg;
    public Image Frn;
    Vector2 touchData;
    Vector3 inputForce;

    public void Update()
    {
        if (GameController.isPause || FairyMovement.isOpenLight)
        {
            Frn.rectTransform.anchoredPosition = new Vector2(0, 0);
            inputForce.Set(0, 0, 0);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (
            Bg.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out touchData
            ))
        {
            float tx = touchData.x / Bg.rectTransform.sizeDelta.x / 2;
            float ty = touchData.y / Bg.rectTransform.sizeDelta.y / 2;

            inputForce = new Vector3(tx, ty, 0);

            if (inputForce.magnitude > 1)
            {
                inputForce.Normalize();
            }

            Frn.rectTransform.anchoredPosition = new Vector2(inputForce.x * (Frn.rectTransform.sizeDelta.x) / 2, inputForce.y * (Frn.rectTransform.sizeDelta.y) / 2);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Frn.rectTransform.anchoredPosition = new Vector2(0, 0);
        inputForce.Set(0, 0, 0);
    }

    public float GetHorizontal()
    {
        return inputForce.x;
    }

    public float GetVertical()
    {
        return inputForce.y;
    }
}
