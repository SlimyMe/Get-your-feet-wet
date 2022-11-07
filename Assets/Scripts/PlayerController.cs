using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController:MonoBehaviour
{
    public const float InitSpeed = 0.05f;

    private PlayerSurrounding _surrounding;

    public Player Player;


    // Start is called before the first frame update
    void Start() {
        if( Player == null ) {
            Player = new Player();
        }
        _surrounding = GetComponent<PlayerSurrounding>();
        _surrounding.CheckSurrounding();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if( Input.GetKey(KeyCode.D) ) {
            this.transform.SetPositionAndRotation(transform.position + new Vector3(Player.Speed, 0, 0), transform.rotation);
            _surrounding.CheckSurrounding();
        } else if( Input.GetKey(KeyCode.A) ) {
            this.transform.SetPositionAndRotation(transform.position + new Vector3(-Player.Speed, 0, 0), transform.rotation);
            _surrounding.CheckSurrounding();
        }
        if( Input.GetKey(KeyCode.W) ) {
            this.transform.SetPositionAndRotation(transform.position + new Vector3(0, Player.Speed, 0), transform.rotation);
            _surrounding.CheckSurrounding();
        } else if( Input.GetKey(KeyCode.S) ) {
            this.transform.SetPositionAndRotation(transform.position + new Vector3(0, -Player.Speed, 0), transform.rotation);
            _surrounding.CheckSurrounding();
        }
        Player.Update(Time.deltaTime);
    }

}
