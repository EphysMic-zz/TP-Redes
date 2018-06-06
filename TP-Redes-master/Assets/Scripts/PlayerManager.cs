using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour {
    //Agregar por instanceid y de ahi hacer el get, o algo asi xd 
    //[SyncVar]

    [SyncVar]
    public int peoples;
    [SyncVar]
    public bool match;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //networkserverconections da cero
        if ( peoples > 1 ) {
            match = true;
        }
    }
    public void AddPlayer( Player player ) {
        //No agrega otra people

        if ( !match ) {
            if ( peoples < 4 ) {

                peoples++;
                player.entered = true;
                player.entToggle.isOn = true;
                return;     //No borrar
            }
        }


    }
}
