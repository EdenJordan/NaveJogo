using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Inimigos : MonoBehaviour
{
    public bool NaveDeAtaque;

    public bool CruzadordeBatalha;

    public GameObject laserInimigo;

    public Transform disparoAreaInimigo;
    
    public float velocidadeInimigo;

    public int inimigoVidaMaxima;

    public int inimigoVidaAtual;

    public int pontosparadar;

    public float tempoMaximoEntreOsLasers;

    public float tempoAtualDosLasers;

    public bool inimigoAtirador;
    
    //programação do escudo:
    
    public int escudoMaximo = 3;
    
    public int escudoAtual;
    
    public bool temEscudo;
    
    public GameObject escudo;

// Start is called before the first frame update
    void Start()
    {
        inimigoVidaAtual = inimigoVidaMaxima;
        escudoAtual = escudoMaximo;
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
        
        // Time.deltatime serve para tornar a perfomance do jogo independente da taxa de atualização.
    }

    private void AtirarLaser()
    {
        tempoAtualDosLasers -= Time.deltaTime;

        if (tempoAtualDosLasers <= 0)
        {
            if (NaveDeAtaque == true)
            {
                float angulo = Random.Range(-30f, 30f);
                Quaternion rotacao = Quaternion.Euler(0f, 0f, 90f + angulo);
                Instantiate(laserInimigo, disparoAreaInimigo.position, rotacao);
                tempoAtualDosLasers = tempoMaximoEntreOsLasers;
            }

            if (CruzadordeBatalha == true)
            {
                float angulo = Random.Range(-60f, 60f);
                Quaternion rotacao = Quaternion.Euler(0f, 0f, 90f + angulo);
                Instantiate(laserInimigo, disparoAreaInimigo.position, rotacao);
                tempoAtualDosLasers = tempoMaximoEntreOsLasers;
            }
        }
    }

    public void MachucarInimigo(int danoRecebido)
    {
        
        if (temEscudo)
        {
            escudoAtual--;
            if (escudoAtual <= 0)
            {
                DesativarEscudo();
            }
            
            return;
        }
        
        inimigoVidaAtual -= danoRecebido;

        if (inimigoVidaAtual <= 0)
        {
            // caso a vida do inimigo seja menor ou igual a 0, o mesmo está morto e será destruiído.
            
            Destroy(this.gameObject);
            
            // Quando o inimigo é destruido, o metodo aumentar pontuação irá aumentar os pontos obtidos pelo jogador.
            
            GameManager.instance.AumentarPontuacao(pontosparadar);
        }
            
            
    }

    public void DesativarEscudo()
    {
        escudo.SetActive(false);
        GetComponent<CapsuleCollider2D>().enabled = false;
        temEscudo = false;
    }
    
        
}






