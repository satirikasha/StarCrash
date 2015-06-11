namespace Ship {
  using UnityEngine;
  using System.Collections;
  using Input;

  public class ShipControl: MonoBehaviour {

    public Joystick ShipInput;

    private Vector2 InputForce;

    void Awake() {
      ShipInput.OnPositionChanged += _ => InputForce = _;
    }

    void Update() {

    }
  }
}
