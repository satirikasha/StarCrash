namespace StarCrash.Ship.Weapons {
  using System.Collections.Generic;
  using UnityEngine;
  using Enviroment;

  public class Clip: IHasParent<Weapon> {

    private Queue<Shot> _ShotQueue;

    public Weapon Parent { get; private set; }

    public void SetParent(Weapon parent) {
      Parent = parent;
    }

    public Clip(Weapon weapon, Shot shot, int capacity) {
      SetParent(weapon);
      _ShotQueue = new Queue<Shot>();
      while(capacity > 0) {
        var instance = Object.Instantiate<Shot>(shot);
        instance.SetParent(this);
        instance.gameObject.SetActive(false);
        instance.transform.parent = Enviroment.Current.transform;
        instance.transform.position = weapon.transform.position;
        _ShotQueue.Enqueue(instance);
        capacity--;
      }
    }

    public Shot GetNextShot() {
      var current = _ShotQueue.Dequeue();
      _ShotQueue.Enqueue(current);
      current.gameObject.SetActive(true);
      current.transform.position = Parent.transform.position;
      current.transform.up = Parent.transform.up;
      current.Rigidbody.velocity = Parent.Parent.Rigidbody.velocity;
      return current;
    }
  }
}

