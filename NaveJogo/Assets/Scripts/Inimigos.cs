using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Inimigos : MonoBehaviour
{
    // booleanas das naves

    public bool NaveDeAtaque;

    public bool CruzadordeBatalha;
    
    //variáveis movimentação errática nave de ataque

    public float movimentoNaveDeAtaque;

    public float velocidadeVertical;

    public float MudarDirecao;

    public float AtualDirecao;

    //
    public GameObject itemDropar;
    
    public GameObject itemDroparRaro;

    public GameObject laserInimigo;

    public int danoParaDar;

    public Transform disparoAreaInimigo;
    
    public float velocidadeInimigo;

    public float inimigoVidaMaxima;

    public float inimigoVidaAtual;

    public int pontosparadar;

    public int chancedeDrop;
    
    public int chancedeDropRaro;

    public float tempoMaximoEntreOsLasers;

    public float tempoAtualDosLasers;

    public bool inimigoAtirador;
    
    //variáveis programação do escudo:
    
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
        AtualDirecao += Time.deltaTime;

        if (NaveDeAtaque)
        {
            if (AtualDirecao >= MudarDirecao)
            {
                movimentoNaveDeAtaque = Random.Range(-velocidadeVertical, velocidadeVertical);
                AtualDirecao = Random.value * MudarDirecao;
            }

            // Time.deltatime serve para tornar a perfomance do jogo independente da taxa de atualização.
        
        transform.Translate((Vector3.left + Vector3.up*movimentoNaveDeAtaque) * velocidadeInimigo * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4, 4),
            transform.position.z);
        }
        else
        {
            transform.Translate(Vector3.left * velocidadeInimigo * Time.deltaTime);
        }
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerVida>().MachucarPlayer(danoParaDar);
            Destroy(this.gameObject);
        }
    }
    
 

    public void MachucarInimigo(float danoRecebido)
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
            GameManager.instance.AumentarPontuacao(pontosparadar);
            int numeroAleatorio = Random.Range(0, 100);
            int numeroAleatorio2 = Random.Range(0, 100);
            if (numeroAleatorio <= chancedeDrop)
            {
                Instantiate(itemDropar, transform.position + new Vector3(1,0,0), quaternion.Euler(0f, 0f, 0f));

            }
            if (numeroAleatorio2 <= chancedeDropRaro)
            {
                Instantiate(itemDroparRaro, transform.position, quaternion.Euler(0f, 0f, 0f));

            }
            Destroy(this.gameObject);
        }

    }

    public void DesativarEscudo()
    {
        escudo.SetActive(false);
        GetComponent<CapsuleCollider2D>().enabled = false;
        temEscudo = false;
    }
    
    
    
        
}







