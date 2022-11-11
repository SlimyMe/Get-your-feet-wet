using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireplaceController:MonoBehaviour, ILightSource
{
    public int WarmPerSecond;

    public void Start() {
        DayNightSystem.Instance.RegistrateLight(this);
    }
    public Light2D Light;
    public void TurnOff() {
        Light.enabled = false;
    }

    public void TurnOn() {
        Light.enabled = true;
    }
    //public void OnTriggerEnter2D(Collider2D other) {
    //    if( other != null ) {
    //        var fireplace = other.gameObject.GetComponent<PlayerController>();
    //        if( fireplace != null ) {
    //            GameData.Player.IsNearFireplace = true;
    //            Debug.Log("Player is near fireplace");
    //        }
    //    }
    //}
    //public void OnTriggerExit2D(Collider2D other) {
    //    if( other != null ) {
    //        var fireplace = other.gameObject.GetComponent<PlayerController>();
    //        if( fireplace != null ) {
    //            GameData.Player.IsNearFireplace = false;
    //            Debug.Log("Player left fireplace");
    //        }
    //    }
    //}
}
