using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WetnessUI:MonoBehaviour
{

    void Start() {
        GameData.Player.RegisterWetnessChange(PlayerWetnessChanged);
    }

    public void PlayerWetnessChanged() {
        this.GetComponent<Slider>().value = GameData.Player.Wetness;
    }
}
