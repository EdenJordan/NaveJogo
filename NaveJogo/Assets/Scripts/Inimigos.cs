using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{

    public GameObject laserInimigo;

    public Transform disparoAreaInimigo;
    
    public float velocidadeInimigo;

    public float tempoMaximoEntreOsLasers;

    public float tempoAtualDosLasers;

    public bool inimigoAtirador;


// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movimentarInimigo();
        if (inimigoAtirador == true)
        { 
            AtirarLaser();
        }
    }

    private void movimentarInimigo()
    {
        transform.Translate(Vector3.left * velocidadeInimigo * Time.deltaTime);
    }

    private void AtirarLaser()
    {
        tempoAtualDosLasers -= Time.deltaTime;

        if (tempoAtualDosLasers <= 0)
        {
            Instantiate(laserInimigo, disparoAreaInimigo.position, Quaternion.Euler(0f, 0f, 90f));
            tempoAtualDosLasers = tempoMaximoEntreOsLasers;

        }
    }
}






