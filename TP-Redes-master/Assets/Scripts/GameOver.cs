using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameOver : NetworkAnimator {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(NetworkServer.connections.Count >= 0)
        {
            //reconectar
            
        }
	}
}
