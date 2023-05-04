using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePlayer : MonoBehaviour
{

    public Rigidbody2D ORigidbody2D;

    public GameObject laserPlayer;

    public Transform DisparoUnicoArea;

    public float velocidadePlayer;

    public bool temLaserDuplo;

    private Vector2 controles;
        
    // Start is called before the first frame update
    void Start()
    {
        temLaserDuplo = false;
    }

    // Update is called once per frame
    void Update()
    {
        movimentarPlayer();
        AtirarLaser();
    }

    private void movimentarPlayer()
    {
        controles = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        ORigidbody2D.velocity = controles.normalized * velocidadePlayer;
    }

    private void AtirarLaser()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(temLaserDuplo == false)
            {
                Instantiate(laserPlayer, DisparoUnicoArea.position, DisparoUnicoArea.rotation);
            }
            
        }
    }
}
