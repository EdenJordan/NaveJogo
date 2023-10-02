using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class Coletaveis : MonoBehaviour
{
    public bool PowerupEscudo;

    public bool PowerupVida;

    public bool PowerupSuperTiro;

    public bool MunicaoFoguete;

    public bool MunicaoLaserContinuo;
    
    public float tempodeVida;

    private void Start()
    {
        Destroy(this.gameObject, tempodeVida);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            if (PowerupEscudo)
            {
                other.gameObject.GetComponent<PlayerVida>().ativarEscudo();
            }
            if (PowerupVida)
            {
                other.gameObject.GetComponent<PlayerVida>().numVidaAtual++;
                other.gameObject.GetComponent<PlayerVida>().UpdateNumVidasTexto();
            }
            if (PowerupSuperTiro)
            {
                other.gameObject.GetComponent<ControlePlayer>().SuperTiro();
            }

            if (MunicaoFoguete)
            {
                other.gameObject.GetComponent<ControlePlayer>().municaofogueteatual = 50;
                other.gameObject.GetComponent<ControlePlayer>().updatemunicaofoguete();
            }

            if (MunicaoLaserContinuo)
            {
                other.gameObject.GetComponent<ControlePlayer>().municaoLaser = 100;
                other.gameObject.GetComponent<ControlePlayer>().updatemunicaolaser();
            }
            
            Destroy(this.gameObject);
        }
    }
}
