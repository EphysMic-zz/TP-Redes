using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PowerUps : MonoBehaviour
{
    public GameObject pl;
    public GameObject spawnPoint;
    public float timer;

    void Update()
    {
        pl = GameObject.FindGameObjectWithTag("pj");

        timer += Time.deltaTime;
        if (timer >= 5)
            Destroy(gameObject);
    }
    public void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.layer == LayerMask.NameToLayer("pj")) Destroy(gameObject);

    }
}
