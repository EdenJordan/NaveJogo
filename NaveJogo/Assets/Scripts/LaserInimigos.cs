using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserInimigos : MonoBehaviour
{
    public float velocidadeDoMissil;
    
    public bool asteroide;

    public bool missilnavemae;

    private Transform target;

    public float velocidaLaser;
    public int danoParaDar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarLaser();
    }

    private void MovimentarLaser()
    {
        if (asteroide)
        {
            transform.Translate(Vector3.left * velocidaLaser * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.up * velocidaLaser * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerVida>().MachucarPlayer(danoParaDar);
            Destroy(this.gameObject);
        }
    }
   
}
