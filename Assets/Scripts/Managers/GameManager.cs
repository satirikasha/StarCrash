﻿namespace StarCrash {
  using UnityEngine;
  using System.Collections;
  using Engine.Utils;

  public class GameManager: MonoBehaviour {

    // Use this for initialization
    void Start() {
      FPSCounter.Instantiate();
      DebugConsole.Instantiate(Screen.width / 3, 10);
    }

    // Update is called once per frame
    void Update() {

    }

    public void Restart() {
      Application.LoadLevel(Application.loadedLevel);
    }
  }
}
