namespace StarCrash.Ship {
  using UnityEngine;
  using System.Collections;

  public class EngineEmissionController: MonoBehaviour {

    public Ship ShipController;
    public ParticleSystem EngineTrail;
    public Light EngineLight;

    private float _NormalEmission;
    private float _NormalLight;

    void Awake() {
      _NormalEmission = EngineTrail.emissionRate;
      _NormalLight = EngineLight.intensity;
      EngineTrail.emissionRate = 0;
      EngineLight.intensity = 0;
    }

    // Update is called once per frame
    void Update() {
      EngineTrail.emissionRate = _NormalEmission * ShipController.Throtle;
      EngineLight.intensity = _NormalLight * ShipController.Throtle;
    }
  }
}
