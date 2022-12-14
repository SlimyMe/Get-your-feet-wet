using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController:MonoBehaviour
{
    public const float InitSpeed = 0.05f;

    private PlayerSurrounding _surrounding;


    // Start is called before the first frame update
    void Awake() {
        if( GameData.Player == null ) {
            GameData.Player = new Player();
            GameData.Player.Surrounding = Surrounding.Land;
        }
        _surrounding = GetComponent<PlayerSurrounding>();
        _surrounding.CheckSurrounding();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if( Input.GetKey(KeyCode.D) ) {
            this.transform.SetPositionAndRotation(transform.position + new Vector3(GameData.Player.Speed, 0, 0), transform.rotation);
            _surrounding.CheckSurrounding();
        } else if( Input.GetKey(KeyCode.A) ) {
            this.transform.SetPositionAndRotation(transform.position + new Vector3(-GameData.Player.Speed, 0, 0), transform.rotation);
            _surrounding.CheckSurrounding();
        }
        if( Input.GetKey(KeyCode.W) ) {
            this.transform.SetPositionAndRotation(transform.position + new Vector3(0, GameData.Player.Speed, 0), transform.rotation);
            _surrounding.CheckSurrounding();
        } else if( Input.GetKey(KeyCode.S) ) {
            this.transform.SetPositionAndRotation(transform.position + new Vector3(0, -GameData.Player.Speed, 0), transform.rotation);
            _surrounding.CheckSurrounding();
        }
        GameData.Player.UpdateWetness(Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if( other != null ) {
            var fireplace = other.gameObject.GetComponent<FireplaceController>();
            if( fireplace != null ) {
                GameData.Player.IsNearFireplace = true;
                Debug.Log("Player is near fireplace");
            }
        }
    }
    public void OnTriggerExit2D(Collider2D other) {
        if( other != null ) {
            var fireplace = other.gameObject.GetComponent<FireplaceController>();
            if( fireplace != null ) {
                GameData.Player.IsNearFireplace = false;
                Debug.Log("Player left fireplace");
            }
        }
    }


}
