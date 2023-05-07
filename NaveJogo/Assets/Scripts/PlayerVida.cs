using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVida : MonoBehaviour
{

    public int playerVidaMaxima;

    public int playerVidaAtual;

    public bool temEscudo;
    // Start is called before the first frame update
    void Start()
    {
        playerVidaAtual = playerVidaMaxima;
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

            if (playerVidaAtual <= 0)
            {
                Debug.Log("Game Over");
            }
        }
        
    }
}
