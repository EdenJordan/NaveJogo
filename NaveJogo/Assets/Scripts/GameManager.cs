using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
        
        // public static serve para indicar para a unity que essa variável é única e referencia o próprio script. 
        
    public int pontuacaoAtual;
        
    // Start is called before the first frame update.
    private void Awake()
    {
        // Awake ao mesmo tempo que o jogo é iniciado, consequentemente antes do Start.

        instance = this;
        
        // variável instance terá como valor o script Gamemanager.

    }

    void Start()
    {
        pontuacaoAtual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AumentarPontuacao(int pontosRecebidos)
    {
        // método precisa ser público para ser acessado por outros scripts.
        
        pontuacaoAtual += pontosRecebidos;
    }
}
