using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public UnityEvent onClick;
    public UnityEvent onRelease;

    bool clicked = false;
    bool iterationLimit = true;

    public void OnPointerDown(PointerEventData eventData)
    {
        clicked = true;
        iterationLimit = true;
        Debug.Log("down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        Debug.Log("up");
    }

    void Update()
    {
        if (clicked)
        {
            if (onClick != null)
            {
                onClick.Invoke();
            }
        } else if (iterationLimit)
        {
            if (onRelease != null)
            {
                onRelease.Invoke();
                iterationLimit = false;
            }
        }
    }

    void Reset()
    {
        clicked = false;
    }

}
