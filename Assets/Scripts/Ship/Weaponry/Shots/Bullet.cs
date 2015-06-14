namespace StarCrash.Ship.Weapons {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using UnityEngine;

  class Bullet : Shot {

    public float Speed;

    private Rigidbody _Rigidbody;

    void Start() {
      Launch();
    }

    public override void Launch() {
      Debug.Log("Launch");
      if(_Rigidbody == null)
        _Rigidbody = this.GetComponent<Rigidbody>();
      _Rigidbody.velocity = this.transform.up * Speed;
    }
  }
}
