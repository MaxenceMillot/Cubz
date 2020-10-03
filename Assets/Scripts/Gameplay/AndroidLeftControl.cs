using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AndroidLeftControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        FindObjectOfType<PlayerMovement>().shoudGoLeft = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        FindObjectOfType<PlayerMovement>().shoudGoLeft = false;
    }
}
