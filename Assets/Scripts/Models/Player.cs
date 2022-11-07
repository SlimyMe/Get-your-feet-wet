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
                _surroundingChange?.Invoke(_surrounding);
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

    private Surrounding _surrounding = Surrounding.Unknown;

    public float Wetness = 0;

    internal void UpdateWetness(float deltaTime) {
        if( Wetness > 0 && _surrounding == Surrounding.Land ) { //slow drying
            Wetness -= (0.005f * deltaTime);
            if( Wetness < 0 )
                Wetness = 0;
            _wetnessChange?.Invoke();
        } else if( Wetness < 1 && _surrounding != Surrounding.Land ) { // geting wet
            switch( _surrounding ) {
            case Surrounding.Water:
                Wetness += (0.01f * deltaTime);
                break;
            case Surrounding.WaterDeep:
                Wetness += (0.03f * deltaTime);
                break;
            case Surrounding.WaterOcean:
                Wetness += (0.06f * deltaTime);
                break;
            }
            if( Wetness > 1 )
                Wetness = 1;
            _wetnessChange?.Invoke();
        }
    }

    #region Actions
    public Action<Surrounding> _surroundingChange;
    public void RegisterSurroundingChange(Action<Surrounding> cb) => _surroundingChange += cb;
    public void UnregisterSurroundingChange(Action<Surrounding> cb) => _surroundingChange -= cb;
    public Action _wetnessChange;
    public void RegisterWetnessChange(Action cb) => _wetnessChange += cb;
    public void UnregisterWetnessChange(Action cb) => _wetnessChange -= cb;
    #endregion
}
