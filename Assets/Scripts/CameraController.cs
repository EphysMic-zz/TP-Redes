using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour {

    public Player pl;
    void Update()
    {
        pl = FindObjectOfType<Player>();
        if (pl)
            Destroy(gameObject);
    }

}
