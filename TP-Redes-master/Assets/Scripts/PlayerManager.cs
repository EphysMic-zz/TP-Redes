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

    }
    public void AddPlayer( Player player ) {
        if ( peoples < 4 ) {
            foreach ( var ui in uIs ) {
                    print(ui.asigned);
                    print(ui.name);
                if ( ui.asigned == false) {
                    players.Add(player);
                    player.pUI = ui;
                    player.pUI.AsignUI("Player " + players.Count , player.life);
                    peoples++;
                }
            }
        }
    }

}
