using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject painel;
    public GameObject painelMenuInicial;
    public GameObject painelControles;
    
    public void jogar()
    {
        GameManager.instance.botoes();
        painel.SetActive(false);
    }

    public void abrircontroles()
    {
        painelMenuInicial.SetActive(false);
        painelControles.SetActive(true);
    }

    public void fecharcontroles()
    {
        painelMenuInicial.SetActive(true);
        painelControles.SetActive(false);
    }

    public void sairdojogo()
    {
        Application.Quit();
        Debug.Log("Sair do jogo");
    }
    
    public void menu()
    {
        SceneManager.LoadScene("menu");
        pausemenu.gameObject.SetActive(false);
    }
}
