using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour {
    //Agregar por instanceid y de ahi hacer el get, o algo asi xd 
    //[SyncVar]
    public List<PlayerUI> uIs = new List<PlayerUI>();


    [SyncVar]
    public int peoples;
    [SyncVar]
    public bool match;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (peoples == NetworkServer.connections.Count && peoples > 1)
        {
            match = true;
        }
    }
    public void AddPlayer( Player player ) {
        //No agrega otra people
        
        if ( !match) {
            if ( peoples < 4 ) {
                foreach ( var ui in uIs ) {
                        print("HEY");
                    if ( ui.asigned == false ) {

                        peoples++;
                        player.pUI = ui;
                        player.pUI.AsignUI("Player " + peoples , player.life);
                        player.entered = true;
                        player.entToggle.isOn = true;
                        return;     //No borrar
                    }
                }
            }
        }
    }
}
