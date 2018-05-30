using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerUI : NetworkBehaviour{
    public string playerName;
    [SyncVar]
    public int lifeValue;

    public bool asigned;
    public Text uiname;
    public Text life;

    public void Repaint(int l ) {
        lifeValue = l;
        life.text = lifeValue + "";
    }

    public void AsignUI(string pn, int l) {
        playerName = pn;
        uiname.text = playerName;
        Repaint(l);
        asigned = true;
    }
}
