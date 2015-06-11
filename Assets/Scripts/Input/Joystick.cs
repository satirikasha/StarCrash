namespace Input {
  using System;
  using UnityEngine;
  using UnityEngine.EventSystems;
  using Engine.Utils;

  public class Joystick: MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {

    public event Action<Vector2> OnPositionChanged;

    public float MovementRange = 100;

    private Vector2 m_StartPos;
    private float _MovementRangeSqr;

    void Start() {
      m_StartPos = transform.position;
      _MovementRangeSqr = MovementRange.deg2();
    }

    private void UpdateVirtualAxes(Vector2 value) {
      var delta = m_StartPos - value;
      delta /= MovementRange;
      OnPositionChanged(delta);
    }

    public void OnDrag(PointerEventData data) {
      Vector3 newPos = Vector3.zero;

      var delta = data.position - m_StartPos;
      if(delta.sqrMagnitude > _MovementRangeSqr) {
        delta.Normalize();
        delta *= MovementRange;
      }
      this.transform.position = m_StartPos + delta;
      UpdateVirtualAxes(transform.position);
    }


    public void OnPointerUp(PointerEventData data) {
      this.transform.position = m_StartPos;
      UpdateVirtualAxes(m_StartPos);
    }


    public void OnPointerDown(PointerEventData data) {
      this.transform.position = data.position;
    }
  }
}