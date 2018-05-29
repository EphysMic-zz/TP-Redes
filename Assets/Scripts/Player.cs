using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Player : NetworkBehaviour
{
    public int speed;
    public int _jumpForce;
    public bool piso;
    public bool estacoosa;
    public Rigidbody rb;
    public PlayerManager pm;
    public PlayerUI pUI;

    [SyncVar]
    public int life;
    [SyncVar]
    public int ammountOfLifes;

    void Start()
    {
        if (!hasAuthority)
            enabled = false;

        rb = GetComponent<Rigidbody>();
        pm = FindObjectOfType<PlayerManager>();
        pm.AddPlayer(this);        //Entonces cada vez que le hacen daño haces un repaint(pui.repaint(life))

    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f);
        rb.AddForce(movement * speed);

        if (Input.GetButton("Jump") && !estacoosa)
        {
            Jump();
            piso = false;
        }

     /*   if (ammountOfLifes <= 0)
        {
            SceneManager.LoadScene("GameOver");    
            //no destruye   
            NetworkServer.Destroy(gameObject);
        }*/

    }

    void Jump()
    {
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

    [ClientRpc]
    public void RpcDealDamage(int dmg)
    {
        life -= dmg;
        if (life <= 0 && ammountOfLifes >= 1)
        {
            transform.position = Vector3.zero;
            life = 100;
            ammountOfLifes--;
        }
    }

    private void OnTriggerStay(Collider c)
    {
        if (c.gameObject.layer == LayerMask.NameToLayer("Line"))
            RpcDealDamage(2);
    }
}
