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

    public GameObject EscudoPlayer;

    public int vidaAtualEscudo;

    public int vidaMaximaEscudo;

    public int numVidaAtual;

    public TextMeshProUGUI numVidasTexto;

    // Start is called before the first frame update
    void Start()
    {
        playerVidaAtual = playerVidaMaxima;
        barradevidaPlayer.maxValue = playerVidaMaxima;
        barradevidaPlayer.value = playerVidaAtual;
        numVidaAtual = 5;
        numVidasTexto.text = "Vidas restantes:" + numVidaAtual;
        
        EscudoPlayer.SetActive(false);
        temEscudo = false;

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
                numVidaAtual--;
                if (numVidaAtual <= 0)
                {
                    GameManager.instance.GameOver();
                    Debug.Log("Game Over");
                }
                else
                {
                    // O jogador ainda tem vidas restantes
                    playerVidaAtual = playerVidaMaxima;
                    barradevidaPlayer.value = playerVidaAtual;
                    UpdateNumVidasTexto();
                    Debug.Log("Perdeu uma vida. Vidas restantes: " + numVidaAtual);
                }
                
            }

        }
        else
        {
            vidaAtualEscudo -= danorecebido;

            if (vidaAtualEscudo <= 0)
            {
                EscudoPlayer.SetActive(false);
                temEscudo = false;
            }
        }
    }

    public void UpdateNumVidasTexto()
    {
        numVidasTexto.text = "Vidas restantes: " + numVidaAtual;
    }
    
    public void ativarEscudo()
    {
        vidaAtualEscudo = vidaMaximaEscudo;
        temEscudo = true;
        EscudoPlayer.SetActive(true);

    }
}
