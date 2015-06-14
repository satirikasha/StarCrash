namespace StarCrash.Ship.Weapons {
  using System.Collections.Generic;
  using UnityEngine;
  using Enviroment;

  public class Clip {

    private Weapon _Weapon;
    private Queue<Shot> _ShotQueue;

    public Clip(Weapon weapon, Shot shot, int capacity) {
      _Weapon = weapon;
      _ShotQueue = new Queue<Shot>();
      while(capacity > 0) {
        var instance = Object.Instantiate<Shot>(shot);
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
      return current;
    }
  }
}

