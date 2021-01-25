using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MovementController : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData) => EventManager.OnTapDown.Invoke();
}
