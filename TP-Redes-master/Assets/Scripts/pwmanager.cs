using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class pwmanager : NetworkBehaviour {
    public GameObject prefabPu;
    public float timer;
    public Vector3 spawnPoint;
    public Quaternion meh;

    void Update() {
        CmdSpawnPowerUp();
    }

    [Command]
    void CmdSpawnPowerUp()
    {
        timer += Time.deltaTime;
        spawnPoint = new Vector3(transform.position.x + Random.Range(-15, 15), transform.position.y, transform.position.z);
        if(timer > 8)
        {
            timer = 0;
            GameObject pu = Instantiate(prefabPu, spawnPoint, meh);
            NetworkServer.Spawn(pu);
        }
    }
}
