using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController:MonoBehaviour
{
    public float InitSpeed;

    private float _speed;

    private PlayerSurrounding _surrounding;


    // Start is called before the first frame update
    void Start() {
        _surrounding = GetComponent<PlayerSurrounding>();
        UpdateSpeed();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if( Input.GetKey(KeyCode.D) ) {
            this.transform.SetPositionAndRotation(transform.position + new Vector3(_speed, 0, 0), transform.rotation);
            if( _surrounding.CheckSurrounding() )
                UpdateSpeed();
        } else if( Input.GetKey(KeyCode.A) ) {
            this.transform.SetPositionAndRotation(transform.position + new Vector3(-_speed, 0, 0), transform.rotation);
            if( _surrounding.CheckSurrounding() )
                UpdateSpeed();
        }
        if( Input.GetKey(KeyCode.W) ) {
            this.transform.SetPositionAndRotation(transform.position + new Vector3(0, _speed, 0), transform.rotation);
            if( _surrounding.CheckSurrounding() )
                UpdateSpeed();
        } else if( Input.GetKey(KeyCode.S) ) {
            this.transform.SetPositionAndRotation(transform.position + new Vector3(0, -_speed, 0), transform.rotation);
            if( _surrounding.CheckSurrounding() )
                UpdateSpeed();
        }
    }

    internal void UpdateSpeed() {
        switch( _surrounding.Current ) {
        case Surrounding.Land:
            _speed = InitSpeed;
            break;
        case Surrounding.Water:
            _speed = (float)(InitSpeed * 0.5);
            break;
        case Surrounding.WaterDeep:
            _speed = (float)(InitSpeed * 0.3);
            break;
        case Surrounding.WaterOcean:
            _speed = (float)(InitSpeed * 0.1);
            break;
        case Surrounding.Unknown:
            _speed = InitSpeed;
            break;
        }
    }


}
