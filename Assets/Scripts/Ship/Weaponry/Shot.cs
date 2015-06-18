namespace StarCrash.Ship.Weapons {
  using UnityEngine;
  using Engine.Utils;

  public abstract class Shot: MonoBehaviour, IHasParent<Clip> {

    public Rigidbody Rigidbody { get; private set; }

    public Clip Parent { get; private set; }

    void Awake() {
      Rigidbody = this.GetComponent<Rigidbody>();
    }

    public void SetParent(Clip parent) {
      Parent = parent;
    }

    public virtual void Launch() { }
  }
}
