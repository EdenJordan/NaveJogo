using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    
    public static GameManager instance;
        
        // public static serve para indicar para a unity que essa variável é única e referencia o próprio script. 


    public TextMeshProUGUI textoPontuacaoAtual;

    public GameObject painelGameOver;

    public TextMeshProUGUI textoPontuacaoFinal;

    public TextMeshProUGUI textoHighScore;
        
    public int pontuacaoAtual;
        
    // Start is called before the first frame update.
    private void Awake()
    {
        // Awake ao mesmo tempo que o jogo é iniciado, antes do Start/primeiro frame.

        instance = this;
        
        // variável instance terá como valor o script Gamemanager.

    }

    void Start()
    {
        Time.timeScale = 1f;
        pontuacaoAtual = 0;
        textoPontuacaoAtual.text = "PONTUAÇÃO: " + pontuacaoAtual;
    }

    // Update is called once per frame
    void Update()
    {

        if(pontuacaoAtual >= 200)
        {
            Time.timeScale = 0f;
        }
        
    }
    

    public void AumentarPontuacao(int pontosRecebidos)
    {
        // método precisa ser público para ser acessado por outros scripts.
        
        pontuacaoAtual += pontosRecebidos;
        textoPontuacaoAtual.text = "PONTUAÇÃO: " + pontuacaoAtual;
    }

    public void GameOver()
    {
        //Set Active = ativa/desativa objeto no inspector da unity
        Time.timeScale = 0f;
        painelGameOver.SetActive(true);
        textoPontuacaoFinal.text = "PONTUAÇÃO: " + pontuacaoAtual;
    }
}
