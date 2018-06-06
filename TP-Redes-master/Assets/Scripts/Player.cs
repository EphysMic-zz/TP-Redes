using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : NetworkBehaviour
{
    public int speed;
    public int _jumpForce;
    public bool piso;
    public bool estacoosa;
    public Rigidbody rb;
    public PlayerManager playerMng;
    [SyncVar]
    public bool entered;
    public Toggle entToggle;
    public bool ready;
    public Canvas canvas;
    [SyncVar]
    public int life;
    [SyncVar]
    public int ammountOfLifes;

    public void Awake()
    {
        playerMng = FindObjectOfType<PlayerManager>();
        
    }
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if ( playerMng.match ) {
            DisableUI();
        }

        if ( !hasAuthority ) {
            enabled=false;
        }
         
        //Inputs
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
public void AddToQueue() {
        if (!entered)
        {
        playerMng.AddPlayer(this);
            entered = true;
        }
}
    public void DisableUI() {
        canvas.enabled = false;
    }
}

