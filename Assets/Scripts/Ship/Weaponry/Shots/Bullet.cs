namespace StarCrash.Ship.Weapons {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using UnityEngine;

  class Bullet : Shot {

    public float Speed;
    public float BulletRotation;

    public override void Launch() {
      Rigidbody.velocity += this.transform.up * Speed;
      Rigidbody.angularVelocity = this.transform.up * BulletRotation;
    }
  }
}
