using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class winner : NetworkBehaviour {

    public GameObject serverWins;
    public GameObject clientWins;
    public bool ctermino;
    private void Update()
    {
        if (ctermino)
            Time.timeScale = 0;
    }
    [ClientRpc]
    public void RpcWin(string winner)
    {
        ctermino = true;
        if (winner == "server")
            serverWins.SetActive(true);
        if (winner == "client")
            clientWins.SetActive(true);
    }
}
