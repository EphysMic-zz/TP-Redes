using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {
    public PlayerManager playerManager;
    public bool match;
    public bool enter;
    public Toggle matchToggle;
	// Use this for initialization
	void Start () {
        match = playerManager.match;
        matchToggle.isOn = match;
    }
    public void AddToQueue()
    {
        if (!match)
        {
            if(playerManager.peoples < 4)
            {
                Player.
            }
            else
            {
                print ("No hay espacio")
            }
        }
        else
        {
            print("Jeugo en progreso");
        }
    }
    public void Launch()
    {
        
    }
	
}
