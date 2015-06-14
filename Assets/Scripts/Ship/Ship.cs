namespace StarCrash.Ship {
  using UnityEngine;
  using System.Collections;
  using Input;
  using Engine.Utils;
  using UnityEngine.UI;
  using Widgets;
  using Weapons;

  public class Ship: MonoBehaviour {
    public Joystick ShipJoystickInput;
    public FireButtonWidget ShipButtonInput;
    public Transform ShipContainer;
    public Weapon[] Weapons;
    public float EngineForce;
    public float AngularDampTime = 0.75f;
    public float MaxAngularVelocity = 180f;

    public float Throtle { get; private set; }

    private ConstantForce _Engine;
    private Rigidbody _Rigidbody;
    private Vector2 _InputForce;
    private bool _IsFireEnabled = false;
    private float _CurrentAngularVelocity = 0;
    private float _CurrentLurchVelocity = 0;

    void Awake() {
      ShipJoystickInput.OnPositionChanged += _ => _InputForce = _;
      ShipButtonInput.OnPoinerDown += () => _IsFireEnabled = true;
      ShipButtonInput.OnPoinerUp += () => _IsFireEnabled = false;
      _Engine = this.GetComponent<ConstantForce>();
      _Rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update() {
      UpdateMovement();
      UpdateFire();
    }

    private void UpdateMovement() {
      if(!Mathf.Approximately(_InputForce.sqrMagnitude, 0)) {
        var angle = Vector2.Angle(Vector2.up, _InputForce);
        angle *= -Mathf.Sign(_InputForce.x);
        angle = Mathf.SmoothDampAngle(_Rigidbody.rotation.eulerAngles.z, angle, ref _CurrentAngularVelocity, AngularDampTime, MaxAngularVelocity);
        _Rigidbody.MoveRotation(Quaternion.Euler(Vector3.forward * angle));
        var lurchAngle = Mathf.SmoothDampAngle(
          ShipContainer.localRotation.eulerAngles.y,
          (_CurrentAngularVelocity * Settings.MaxLurchAngle) / MaxAngularVelocity,
          ref _CurrentLurchVelocity,
          AngularDampTime / Settings.Lurch2Angular);
        ShipContainer.localRotation = Quaternion.Euler(Vector3.up * lurchAngle);
      }
      else {
        var lurchAngle = Mathf.SmoothDampAngle(
          ShipContainer.localRotation.eulerAngles.y,
          0,
          ref _CurrentLurchVelocity,
          AngularDampTime / Settings.Lurch2Angular);
        ShipContainer.localRotation = Quaternion.Euler(Vector3.up * lurchAngle);
      }
      Throtle = Mathf.Clamp01(Vector2.Dot(this.transform.up.ToVector2(), _InputForce));
      _Engine.relativeForce = Vector3.up * EngineForce * Throtle;
    }

    public void UpdateFire() {
      if(_IsFireEnabled) {
        foreach(var w in Weapons)
          w.Fire();
      }
    }
  }
}
