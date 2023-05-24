using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ControlePlayer : MonoBehaviour
{
    
    public float Direita, Esquerda, Cima, Baixo;

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
        JogadorPreso();
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

    private void JogadorPreso()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, Esquerda, Direita),
            Mathf.Clamp(transform.position.y, Baixo, Cima), transform.position.z);
    }

}
