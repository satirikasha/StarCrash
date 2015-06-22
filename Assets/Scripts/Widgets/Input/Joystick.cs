namespace StarCrash.Input {
  using System;
  using UnityEngine;
  using UnityEngine.EventSystems;
  using Engine.Utils;
using UnityEngine.UI;
using System.Collections;

  public class Joystick: MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {

    public event Action<Vector2> OnPositionChanged;

    private float _MovementRange = 100;
    private Vector2 _StartPos;
    private float _MovementRangeSqr;
    private float _CurrentPointerID;
    private bool _RecieveInput = true;

    void Start() {
      _StartPos = transform.position;
      var parent = this.transform.parent as RectTransform;
      _MovementRange = Mathf.Min(parent.rect.width, parent.rect.height) / 2;
      _MovementRangeSqr = _MovementRange.deg2();
    }

    private void UpdateVirtualAxes(Vector2 value) {
      var delta = _StartPos - value;
      delta = -delta;
      delta /= _MovementRange;
      OnPositionChanged(delta);
    }

    public void OnDrag(PointerEventData data) {
      Vector3 newPos = Vector3.zero;

      var delta = data.position - _StartPos;
      if(delta.sqrMagnitude > _MovementRangeSqr) {
        delta.Normalize();
        delta *= _MovementRange;
      }
      this.transform.position = _StartPos + delta;
      UpdateVirtualAxes(transform.position);
    }


    public void OnPointerUp(PointerEventData data) {
      Debug.Log("Joystick up: " + _CurrentPointerID);
      this.transform.position = _StartPos;
      UpdateVirtualAxes(_StartPos);
    }


    public void OnPointerDown(PointerEventData data) {
      Debug.Log("Joystick down: " + _CurrentPointerID);
      this.transform.position = data.position;
      _CurrentPointerID = data.pointerId;
    }

    private IEnumerator BlockInputForOneFrame() {
      _RecieveInput = false;
      yield return new WaitForSeconds(1f);
      _RecieveInput = true;
    }
  }
}