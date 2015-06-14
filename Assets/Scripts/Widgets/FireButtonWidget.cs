namespace StarCrash.Widgets {
  using UnityEngine;
  using System.Collections;
  using UnityEngine.EventSystems;
  using System;

  public class FireButtonWidget: MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public event Action OnPoinerDown;
    public event Action OnPoinerUp;

    public void OnPointerDown(PointerEventData eventData) {
      OnPoinerDown();
    }

    public void OnPointerUp(PointerEventData eventData) {
      OnPoinerUp();
    }
  }
}
