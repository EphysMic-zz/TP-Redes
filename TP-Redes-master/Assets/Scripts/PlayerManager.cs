using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour {
    //[SyncVar]
    public List<Player> players = new List<Player>();
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
        int readys = 0;
        if (peoples > 1 ) {
            foreach ( var player in players ) {
                player.readToggle.interactable = true;
                if (player.ready == true ) {
                    readys++;
                }else if (player.ready == false ) {
                    readys--;
                }
            }
            if (readys == peoples ) {
                match = true;
            }
        } else {
            foreach ( var player in players ) {
                player.readToggle.interactable = false;
            }
        }

    }

    public void AddPlayer( Player player ) {
                        print("HEY");
        
        if ( !match) {
            if ( peoples < 4 ) {
                foreach ( var ui in uIs ) {
                    if ( ui.asigned == false ) {

                        players.Add(player);
                        player.pUI = ui;
                        player.pUI.AsignUI("Player " + players.Count, player.life);
                        player.entered = true;
                        player.entToggle.isOn = true;
                        peoples++;
                    }
                }
            }
        }
    }
}
