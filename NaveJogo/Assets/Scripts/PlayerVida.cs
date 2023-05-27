using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class PlayerVida : MonoBehaviour
{
    public Slider barradevidaPlayer;
    
    // 

    public int playerVidaMaxima;

    public int playerVidaAtual;

    public bool temEscudo;

    public int numVidaAtual;

    public TextMeshProUGUI numVidas;
    // Start is called before the first frame update
    void Start()
    {
        playerVidaAtual = playerVidaMaxima;

        barradevidaPlayer.maxValue = playerVidaMaxima;

        barradevidaPlayer.value = playerVidaAtual;

        numVidaAtual = 5;

        numVidas.text = "Vidas restantes:" + numVidaAtual;

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
                GameManager.instance.GameOver();
                Debug.Log("Game Over");
            }
        }
        
    }
    
}
