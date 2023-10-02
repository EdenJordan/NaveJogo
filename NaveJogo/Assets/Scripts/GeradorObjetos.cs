using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GeradorObjetos : MonoBehaviour
{

    public GameManager gameManager;

    public GameObject[] objetosParaSpawnar;

    public Transform[] pontosDeSpawn;

    public GameObject Navemae;

    public float tempoMaximoEntreOsSpawns;

    public float tempoAtualDosSpawns;
    
    public float tempoEspera = 15f; // Tempo de espera em segundos da fase dos meteoros

    private bool canStart = false;

    private bool navemaeInstanciada = false;
    
    // Start is called before the first frame update
    public void Start()
    {
        Invoke("Fase2", tempoEspera);
        tempoAtualDosSpawns = tempoMaximoEntreOsSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (canStart && !navemaeInstanciada) // verifica se pode spawnar e se a navemae ainda não foi instanciada
        {
            tempoAtualDosSpawns -= Time.deltaTime;
            if (tempoAtualDosSpawns <= 0)
            {
                SpawnarObjeto();
            }
        }
    }
    
    private void Fase2()
    {
        canStart = true;
    }

    private void SpawnarObjeto()
    {
        if (gameManager.pontuacaoAtual >= 200)
        {
            Instantiate(Navemae, pontosDeSpawn[0].position, quaternion.Euler(0f, 0f, 0f));
            navemaeInstanciada = true;
            

        }
        else
        {
            int objetoAleatorio = Random.Range(0, objetosParaSpawnar.Length);
            int pontoAleatorio = Random.Range(0, pontosDeSpawn.Length);

            Instantiate(objetosParaSpawnar[objetoAleatorio], pontosDeSpawn[pontoAleatorio].position,
                quaternion.Euler(0f, 0f, 0f));

            tempoAtualDosSpawns = tempoMaximoEntreOsSpawns;
        }
            
        
    }
    
}
