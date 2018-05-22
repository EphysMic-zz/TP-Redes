using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    public int speed;
    public int _jumpForce;
    public Rigidbody rb;
    public bool piso;
    public bool estacoosa;

    [SyncVar]
    int life;

    void Start() {
        if (!hasAuthority)
            enabled = false;
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f);
        rb.AddForce(movement * speed);

        if (Input.GetButton("Jump") && !estacoosa)
        {
            CmdJump();
            piso = false;
        }
    }

    [Command]
    void CmdJump() {
        rb.AddForce(Vector3.up * _jumpForce);
        estacoosa = true;

        if (piso)
            piso = false;
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.layer == LayerMask.NameToLayer("Level") && !piso)
        {
            piso = true;
            estacoosa = false;
        }
    }
}
