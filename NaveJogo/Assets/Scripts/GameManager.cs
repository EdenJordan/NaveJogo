using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
        
        // public static serve para indicar para a unity que essa variável é única e referencia o próprio script. 


    public TextMeshProUGUI textoPontuacaoAtual;

    public GameObject playerstart;

    public GameObject objetoplayer;
    public GameObject painelGameOver;
    public GameObject painelVitoria;

    public TextMeshProUGUI textoPontuacaoFinalGO;
    public TextMeshProUGUI textoPontuacaoFinalVi;

    public int pontuacaoAtual;
        
    // Start is called before the first frame update.
    private void Awake()
    {
        // Awake ao mesmo tempo que o jogo é iniciado, antes do Start/primeiro frame.

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        
        
        // variável instance terá como valor o script Gamemanager.

    }

    void Start()
    
    {
        SceneManager.LoadScene("menu");
        Time.timeScale = 1f;
        pontuacaoAtual = 0;
        textoPontuacaoAtual.text = "PONTUAÇÃO: " + pontuacaoAtual;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }


    public void botoes()
    {
        SceneManager.LoadScene("GUI");
        SceneManager.LoadSceneAsync("Level", LoadSceneMode.Additive).completed += delegate(AsyncOperation operation)
        {
            playerstart = GameObject.Find("playerstart");
            Instantiate(objetoplayer, playerstart.transform.position, Quaternion.Euler(0, 0, 0));
        };
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
        textoPontuacaoFinalGO.text = "PONTUAÇÃO: " + pontuacaoAtual;
        
    }

    public void Vitoria()
    {
        Time.timeScale = 0f;
        painelVitoria.SetActive(true);
        textoPontuacaoFinalVi.text = "PONTUAÇÃO: " + pontuacaoAtual;
    }
}
