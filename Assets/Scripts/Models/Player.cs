using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public float Speed { get; private set; }
    public Surrounding Surrounding {
        set {
            if( value != _surrounding ) {
                _surrounding = value;
                _surroundingChange(_surrounding);
                switch( _surrounding ) {
                case Surrounding.Water:
                    Speed = (float)(PlayerController.InitSpeed * 0.5);
                    break;
                case Surrounding.WaterDeep:
                    Speed = (float)(PlayerController.InitSpeed * 0.3);
                    break;
                case Surrounding.WaterOcean:
                    Speed = (float)(PlayerController.InitSpeed * 0.1);
                    break;
                default:
                    Speed = PlayerController.InitSpeed;
                    break;
                }
            }
        }
        get { return _surrounding; }
    }

    private Surrounding _surrounding;

    public float Wetness = 0;



    internal void Update(float deltaTime) {

    }

    #region Actions
    public Action<Surrounding> _surroundingChange;
    public void RegisterSurroundingChange(Action<Surrounding> cb) => _surroundingChange += cb;
    public void UnregisterSurroundingChange(Action<Surrounding> cb) => _surroundingChange -= cb;
    #endregion
}
