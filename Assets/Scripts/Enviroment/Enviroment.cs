namespace StarCrash.Enviroment {
  using UnityEngine;
  using System.Collections;

  public class Enviroment: MonoBehaviour {

    public static Enviroment Current {
      get {
        return _Current;
      }
    }
    private static Enviroment _Current;

    void Awake() {
      if(_Current != null) {
        Debug.LogError("Only one enviroment item can exist in the scene");
      }
      else {
        _Current = this;
      }
    }
  }
}
