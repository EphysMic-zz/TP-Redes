using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : NetworkBehaviour {
    public int speed;
    public int _jumpForce;
    public bool piso;
    public bool estacoosa;
    public Rigidbody rb;
    public PlayerManager playerMng;
    [SyncVar]
    public bool entered;
    public Toggle entToggle;
    public Toggle matchToggle;
    public Canvas canvas;
    [SyncVar]
    public float force;

    public string type;
    public Winner winner;

    public void Awake() {
        playerMng = FindObjectOfType<PlayerManager>();
        if ( hasAuthority ) {
            EnableUI();
            print("HEY;");
            //enabled = false;
        }else {

        }
    }
    void Start() {

        matchToggle.isOn = playerMng.match;
        rb = GetComponent<Rigidbody>();
        winner = GameObject.Find("winner").GetComponent<Winner>();

        if ( !isLocalPlayer ) {
            if ( isServer )
                type = "server";
            if ( isClient )
                type = "client";
        }

    }

    void Update() {
        if ( playerMng.match && entered ) {
            DisableUI();
        }

        if ( !isLocalPlayer ) {
            //enabled = false;
            DisableUI();
            return;
        }

        //  print(NetworkServer.connections.Count);
        if ( playerMng.match && entered ) {
            float moveHorizontal = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f);
            rb.AddForce(movement * speed);

            if ( Input.GetButton("Jump") && !estacoosa ) {
                Jump();
                piso = false;
            }
        }
    }

    void Jump() {
        rb.AddForce(Vector3.up * _jumpForce);
        estacoosa = true;

        if ( piso )
            piso = false;
    }

    [ClientRpc]
    public void RpcDealDamage() {
        //NetworkServer.Destroy(gameObject);

        playerMng.peoples--;

        if ( playerMng.match && playerMng.peoples == 1 ) {
            //Cambiodeescena.
            winner.RpcWin(type);
        }
    }

    [ClientRpc]
    void RpcPw() {
        force = 50;
    }

    [Command]
    void CmdHit() {
        rb.AddExplosionForce(force, transform.position, 5, 0f, ForceMode.Impulse);
    }

    private void OnTriggerExit( Collider c ) {
        if ( c.gameObject.layer == LayerMask.NameToLayer("Line") )
            RpcDealDamage();
    }

    private void OnCollisionEnter( Collision c ) {
        if ( c.gameObject.layer == LayerMask.NameToLayer("Level") && !piso ) {
            piso = true;
            estacoosa = false;
        }

        if ( c.gameObject.layer == LayerMask.NameToLayer("powerUp") )
            RpcPw();
        if ( c.gameObject.layer == LayerMask.NameToLayer("pj") )
            CmdHit();

    }
    public void AddToQueue() {
        if ( !entered && !playerMng.match ) {
            playerMng.AddPlayer(this);
            entered = true;

        }
    }
    public void DisableUI() {
        canvas.enabled = false;
    }
    public void EnableUI() {
        canvas.enabled = true;
    }

    public override void OnStartLocalPlayer() {
        if ( isClient )
            type = "client";
        if ( isServer )
            type = "server";
    }

}