using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class NaveMae : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject barradevidaNaveMaeAtivador;

    public Slider barradevidaNaveMae;

    public int danoParaDar;

    public Transform disparoAreaInimigo;

    public float velocidadeInimigo;

    public float NaveMaeVidaMaxima;

    public float NaveMaeVidaAtual;

    public int pontosparadar;

    public float tempoMaximoEntreOsLasers;

    public float tempoAtualDosLasers;

    public GameObject laserInimigo;

    public bool temEscudo;

    public GameObject RaioEnergia;

    public GameObject Misseis;

    //variáveis programação do escudo:

    public int escudoMaximo = 3;

    public int escudoAtual;

    public GameObject escudo;
    
    public float Direita, Esquerda, Cima, Baixo;
    
    //variáveis da tela de vitória após navemãe ser destruida:

    public GameObject telaVitoria;

    public float tempoAguardarTelaVitoria = 5f;

    // Start is called before the first frame update
    void Start()
    {
        barradevidaNaveMaeAtivador.SetActive(false);
        NaveMaeVidaAtual = NaveMaeVidaMaxima;
        escudoAtual = escudoMaximo;
        barradevidaNaveMae.maxValue = NaveMaeVidaMaxima;
        barradevidaNaveMae.value = NaveMaeVidaAtual;
        telaVitoria.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.pontuacaoAtual >= 200)
        {
            barradevidaNaveMaeAtivador.SetActive(true);
        }

        movimentarnavemae();
        AtirarLaser();
        NaveMaeLimite();
    }

    private void movimentarnavemae()
    {
        transform.Translate(Vector3.left * velocidadeInimigo * Time.deltaTime);
    }

    private void AtirarLaser()
    {
        if (NaveMaeVidaAtual >= 120)
        {
            tempoAtualDosLasers -= Time.deltaTime;

            if (tempoAtualDosLasers <= 0)
            {
                float angulo = Random.Range(-90f, 90f);
                Quaternion rotacao = Quaternion.Euler(0f, 0f, 90f + angulo);
                Instantiate(laserInimigo, disparoAreaInimigo.position, rotacao);
                tempoAtualDosLasers = tempoMaximoEntreOsLasers;
            }

        }

        if (NaveMaeVidaAtual >= 60 && NaveMaeVidaAtual < 120)
        {
            tempoAtualDosLasers -= Time.deltaTime;

            if (tempoAtualDosLasers <= 0)
            {
                GameObject jogador = GameObject.FindGameObjectWithTag("Player");
                if (jogador != null)
                {
                    // Calcular a direção do jogador em relação ao inimigo
                    Vector3 direcaoJogador = jogador.transform.position - disparoAreaInimigo.position;
                    Quaternion rotacao = Quaternion.LookRotation(Vector3.forward, direcaoJogador);

                    Instantiate(Misseis, disparoAreaInimigo.position, rotacao);
                    tempoAtualDosLasers = tempoMaximoEntreOsLasers;
                }
            }
        }

        if (NaveMaeVidaAtual < 60)
        {
            tempoAtualDosLasers -= Time.deltaTime;

            if (tempoAtualDosLasers <= 0)
            {
                GameObject jogador = GameObject.FindGameObjectWithTag("Player");
                if (jogador != null)
                {

                    // Instancia o raio de energia
                    GameObject raioEnergia = Instantiate(RaioEnergia, disparoAreaInimigo.position,
                        disparoAreaInimigo.rotation);

                    // Faz com que o raio de energia siga o jogador
                    RaioEnergia movimentoRaio = raioEnergia.GetComponent<RaioEnergia>();
                    movimentoRaio.DefinirAlvo(jogador.transform);

                    tempoAtualDosLasers = tempoMaximoEntreOsLasers;
                }
            }
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

        NaveMaeVidaAtual -= danoRecebido;
        barradevidaNaveMae.value = NaveMaeVidaAtual;

        if (NaveMaeVidaAtual <= 0)
        {
            GameManager.instance.AumentarPontuacao(pontosparadar);
            Destroy(this.gameObject);
            barradevidaNaveMaeAtivador.SetActive(false);
            GameManager.instance.Vitoria();
            
        }
    }

    public void DesativarEscudo()
    {
        escudo.SetActive(false);
        GetComponent<CapsuleCollider2D>().enabled = false;
        temEscudo = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerVida>().MachucarPlayer(danoParaDar);
        }
    }
    
    private void NaveMaeLimite()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, Esquerda, Direita),
            Mathf.Clamp(transform.position.y, Baixo, Cima), transform.position.z);
    }
    private void AtivarTelaVitoria()
    {
        Time.timeScale = 0;
        telaVitoria.SetActive(true);
    }

}


