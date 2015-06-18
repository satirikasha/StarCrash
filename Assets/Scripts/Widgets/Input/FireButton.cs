namespace StarCrash.Widgets {
  using UnityEngine;
  using System.Collections;
  using UnityEngine.EventSystems;
  using System;
using UnityEngine.UI;

  public class FireButton: MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public event Action OnPoinerDown;
    public event Action OnPoinerUp;

    public Text Text;

    private int _CurrentPointerID;

    public void OnPointerDown(PointerEventData eventData) {
      _CurrentPointerID = eventData.pointerId;
      Text.text = "Button down: " + _CurrentPointerID;
      OnPoinerDown();
    }

    public void OnPointerUp(PointerEventData eventData) {
      Text.text = "Button up: " + _CurrentPointerID;
      if(_CurrentPointerID == eventData.pointerId) {
        OnPoinerUp();
      }
    }
  }
}
