using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GeradorObjetos : MonoBehaviour
{

    public GameObject[] objetosParaSpawnar;

    public Transform[] pontosDeSpawn;

    public float tempoMaximoEntreOsSpawns;

    public float tempoAtualDosSpawns;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        tempoAtualDosSpawns = tempoMaximoEntreOsSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        tempoAtualDosSpawns -= Time.deltaTime;
        if (tempoAtualDosSpawns <= 0)
        {
            SpawnarObjeto();
        }
    }

    private void SpawnarObjeto()
    {
        int objetoAleatorio = Random.Range(0, objetosParaSpawnar.Length);
        int pontoAleatorio = Random.Range(0, pontosDeSpawn.Length);

        Instantiate(objetosParaSpawnar[objetoAleatorio], pontosDeSpawn[pontoAleatorio].position,
            quaternion.Euler(0f, 0f, 0f));

        tempoAtualDosSpawns = tempoMaximoEntreOsSpawns;
    }
}
