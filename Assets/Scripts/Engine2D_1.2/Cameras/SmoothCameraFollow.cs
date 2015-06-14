namespace Engine.Cameras {
  using UnityEngine;
  using System.Collections;
  using Utils;

  public class SmoothCameraFollow: MonoBehaviour {

    public float SmoothTime;
    public Transform Target;

    private Camera Camera;

    private Vector2 _CurrentCameraSpeed = Vector2.zero;

    // Use this for initialization
    void Start() {
      Camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
      this.transform.position = Vector2.SmoothDamp(this.transform.position, Target.position, ref _CurrentCameraSpeed, SmoothTime)
        .ToVector3(this.transform.position.z);
    }
  }
}
