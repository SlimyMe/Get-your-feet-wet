using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DayNightSystem:MonoBehaviour
{

    public static DayNightSystem Instance;
    void OnEnable() {
        if( Instance != null ) {
            Debug.LogError("DayNightSystem: There should not be more than one system.");
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update() {
        if( transitionTimeLeft > 0 ) {
            transitionTimeLeft -= Time.deltaTime;
            if( transitionTimeLeft <= 0 )
                transitionTimeLeft = 0;

            var value = transitionTimeLeft / TransitionTime;
            if( nightOn == true ) {
                NightVolume.weight = value;
                if( lightOn && transitionTimeLeft < LightSwitchTime ) {
                    foreach( var light in _lightSources ) {
                        light.TurnOff();
                    }
                    lightOn = false;
                }
            } else {
                NightVolume.weight = 1 - value;
                if( !lightOn && transitionTimeLeft < LightSwitchTime ) {
                    foreach( var light in _lightSources ) {
                        light.TurnOn();
                    }
                    lightOn = true;
                }
            }
            if( transitionTimeLeft == 0 ) {
                nightOn = !nightOn;
            }
        }
    }
    public Volume NightVolume;
    public float TransitionTime;
    public float LightSwitchTime;
    private float transitionTimeLeft;
    bool nightOn = false;
    bool lightOn = false;

    public void StartDay() {
        transitionTimeLeft = TransitionTime;
    }
    public void StartNight() {
        transitionTimeLeft = TransitionTime;
    }


    List<ILightSource> _lightSources = new List<ILightSource>();
    public void RegistrateLight(ILightSource source) {
        _lightSources.Add(source);
        //turn on if current time of day night
    }
    public void UnregistrateLight(ILightSource source) {
        _lightSources.Remove(source);
        //turn off if current time of day night
    }

}
