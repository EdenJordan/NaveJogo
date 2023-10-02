using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;


public class ControlePlayer : MonoBehaviour
{
    //Indicadores visuais de cada arma:
    public GameObject ativo1;
    public GameObject ativo2;
    public GameObject ativo3;
    //variavel do numero da arma equipada:
    public int numeroArma;
    //Armas diferentes:
    public GameObject superTiro;
    public GameObject laserLongo;
    public GameObject FoguetePlayer;
    public GameObject laserPlayer;
    public bool temLaserDuplo;
    public Transform DisparoUnicoArea;
    public int municaofogueteatual;
    public TextMeshProUGUI municaofoguetetexto;
    public TextMeshProUGUI municaolasertexto;

    public float Direita, Esquerda, Cima, Baixo;
    public Rigidbody2D ORigidbody2D;
    public float velocidadePlayer;

    private Vector2 controles;
    private bool laserAtivo;
    public float municaoLaser;

    // Start is called before the first frame update
    void Start()
    {
        numeroArma = 1;
        temLaserDuplo = false;
        municaofogueteatual = 0;
        municaofoguetetexto.text =  municaofogueteatual.ToString();
        laserAtivo = false;
        municaoLaser = 100f;
        municaolasertexto.text = municaoLaser + "%";

    }

    // Update is called once per frame
    void Update()
    {
        JogadorPreso();
        movimentarPlayer();
        AtirarLaser();
        AtirarFoguete();
        TrocarArma();
        IndicadordeArma();
        AtirarLaserContinuo();
    }

    private void movimentarPlayer()
    {
        controles = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        ORigidbody2D.velocity = controles.normalized * velocidadePlayer;
    }

    private void JogadorPreso()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, Esquerda, Direita),
            Mathf.Clamp(transform.position.y, Baixo, Cima), transform.position.z);
    }

    private void TrocarArma()
    {
        if (Input.GetButtonDown("TrocarArma"))
        {
            if (numeroArma >= 1)
            {
                numeroArma++;
            }
            if (numeroArma > 3)
            {
                numeroArma = 1;
            }
        }
    }

    private void IndicadordeArma()
    {
        if (numeroArma == 1)
        {
            ativo1.SetActive(true);
            ativo2.SetActive(false);
            ativo3.SetActive(false);
        }
        if (numeroArma == 2)
        {
            ativo1.SetActive(false);
            ativo2.SetActive(true);
            ativo3.SetActive(false);
        }
        if (numeroArma == 3)
        {
            ativo1.SetActive(false);
            ativo2.SetActive(false);
            ativo3.SetActive(true);
        }
    }
    
    private void AtirarLaser()
    {
        if (Input.GetButtonDown("Fire1") && numeroArma == 1)
        {
            Instantiate(laserPlayer, DisparoUnicoArea.position, DisparoUnicoArea.rotation);
        }
    }

    private void AtirarFoguete()
    {
        if (Input.GetButtonDown("Fire1") && municaofogueteatual > 0 & numeroArma == 2)
        {
            municaofogueteatual--;
            updatemunicaofoguete();
            Instantiate(FoguetePlayer, DisparoUnicoArea.position, DisparoUnicoArea.rotation);
        }
    }
    public void AtirarLaserContinuo()
    {
        if (Input.GetButtonDown("Fire1") && municaoLaser > 0f && numeroArma == 3)
        {
            laserAtivo = true;
            StartCoroutine(DispararLaserContinuo());
        }
        else if (Input.GetButtonUp("Fire1") || numeroArma != 3)
        {
            laserAtivo = false;
        }
    }
    public IEnumerator DispararLaserContinuo()
    {
        while (laserAtivo && municaoLaser > 0f)
        {
            Instantiate(laserLongo, DisparoUnicoArea.position, DisparoUnicoArea.rotation);
            municaoLaser -= 0.1f; // diminuir a munição do laser em 0.1% a cada frame
            updatemunicaolaser();
            yield return null;
        }
    }
    public void updatemunicaolaser()
    {
        //nova variavel laserint que assumirá o valor float da municaolaser convertida para inteiro. Em seguida irá exibir no unity pelo municaolaser.text
        int laserint = Mathf.RoundToInt(municaoLaser);
        municaolasertexto.text = laserint + "%";
    }
    
    public void updatemunicaofoguete()
    {
        municaofoguetetexto.text =  municaofogueteatual.ToString();
    }

    public void SuperTiro()
    {
        Instantiate(superTiro, DisparoUnicoArea.position, DisparoUnicoArea.rotation);
        Instantiate(superTiro, DisparoUnicoArea.position, DisparoUnicoArea.rotation);
    }
    
    
}