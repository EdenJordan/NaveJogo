using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{

    public GameObject laserInimigo;

    public Transform disparoAreaInimigo;
    
    public float velocidadeInimigo;

    public int inimigoVidaMaxima;

    public int inimigoVidaAtual;

    public int pontosparadar;

    public float tempoMaximoEntreOsLasers;

    public float tempoAtualDosLasers;

    public bool inimigoAtirador;


// Start is called before the first frame update
    void Start()
    {
        inimigoVidaAtual = inimigoVidaMaxima;
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
            Instantiate(laserInimigo, disparoAreaInimigo.position, Quaternion.Euler(0f, 0f, 90f));
            tempoAtualDosLasers = tempoMaximoEntreOsLasers;

        }
    }

    public void MachucarInimigo(int danoRecebido)
    {
        inimigoVidaAtual -= danoRecebido;

        if (inimigoVidaAtual <= 0)
        {
            // caso a vida do inimigo seja menor ou igual a 0, o mesmo está morto e será destruiído.
            
            Destroy(this.gameObject);
            
            // Quando o inimigo é destruido, o metodo aumentar pontuação irá aumentar os pontos obtidos pelo jogador.
            
            GameManager.instance.AumentarPontuacao(pontosparadar);
        }
            
            
    }
}






