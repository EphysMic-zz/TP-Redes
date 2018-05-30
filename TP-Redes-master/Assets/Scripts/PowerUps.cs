using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {
    public GameObject pl;

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
		
         pl = GameObject.FindGameObjectWithTag("pj");
	}
    public void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.layer == LayerMask.NameToLayer("pj"))
        {
            Destroy(gameObject);
            //aca todo el coso
        }
    }
}
