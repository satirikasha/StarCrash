namespace StarCrash.Ship.Weapons {
  using UnityEngine;
  using Engine.Utils;

  public abstract class Weapon: MonoBehaviour, IHasParent<Ship> {

    public float CoolDown;
    public Shot Shot;
    public int ClipSize;

    protected bool Rearmed;
    protected Clip Clip;

    public Ship Parent { get; private set; }

    public void SetParent(Ship parent) {
      Parent = parent;
    }

    void Start() {
      Rearmed = true;
      Clip = new Clip(this, Shot, ClipSize);
    }

    public virtual void Fire() {
      if(!Rearmed)
        return;

      Rearmed = false;
      StartCoroutine(Utils.DelayedAction(_ => Rearmed = true, time : CoolDown));
      Clip.GetNextShot().Launch();
    }

    
  }
}
