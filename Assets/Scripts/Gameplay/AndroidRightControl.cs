using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AndroidRightControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        FindObjectOfType<PlayerMovement>().shoudGoRight = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        FindObjectOfType<PlayerMovement>().shoudGoRight = false;
    }
}
