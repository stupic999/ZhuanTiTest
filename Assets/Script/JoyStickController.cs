using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    Vector2 touchData;
    Vector3 inputForce;
    public Image Bg;
    public Image Frn;
    public Image MoveBg;

    void Start()
    {
        touchData.Set(0, 0);
        inputForce.Set(0, 0, 0);
    }

    void Update()
    {
        if (gameControllerScriptableObject.isPause || gameControllerScriptableObject.isOpenLight)
        {
            Frn.rectTransform.anchoredPosition = new Vector2(0, 0);
            inputForce.Set(0, 0, 0);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (
            MoveBg.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out touchData
            ))
        {
            float tx = touchData.x / Bg.rectTransform.sizeDelta.x;
            float ty = touchData.y / Bg.rectTransform.sizeDelta.y;

            inputForce = new Vector3(tx, ty, 0);
            if (inputForce.magnitude > 1)
            {
                inputForce.Normalize();
            }
            Debug.Log(inputForce);
            Frn.rectTransform.anchoredPosition = new Vector2(inputForce.x * (Frn.rectTransform.sizeDelta.x) / 2, inputForce.y * (Frn.rectTransform.sizeDelta.y) / 2);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 v2 = new Vector2((1.0f / Screen.width) * Input.mousePosition.x, (1.0f / Screen.height) * Input.mousePosition.y);
        Vector2 temp = new Vector2(v2.x * Screen.width - Screen.width / 12.8f, v2.y * Screen.height - Screen.height / 7.2f);
        Bg.rectTransform.anchoredPosition = temp;
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Frn.rectTransform.anchoredPosition = new Vector2(0, 0);
        Bg.rectTransform.anchoredPosition = new Vector2(50, 50);
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
