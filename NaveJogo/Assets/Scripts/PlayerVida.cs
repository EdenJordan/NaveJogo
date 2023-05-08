using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerVida : MonoBehaviour
{
    public Slider barradevidaPlayer;
    
    // 

    public int playerVidaMaxima;
    
    // Vida maxima do jogador 

    public int playerVidaAtual;
    
    // Vida atual do jogador

    public bool temEscudo;
    // Start is called before the first frame update
    void Start()
    {
        playerVidaAtual = playerVidaMaxima;

        barradevidaPlayer.maxValue = playerVidaMaxima;

        barradevidaPlayer.value = playerVidaAtual;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MachucarPlayer(int danorecebido)
    {
        if (temEscudo == false)
        {
            playerVidaAtual -= danorecebido;

            barradevidaPlayer.value = playerVidaAtual;

            if (playerVidaAtual <= 0)
            {
                Debug.Log("Game Over");
            }
        }
        
    }
    
}
