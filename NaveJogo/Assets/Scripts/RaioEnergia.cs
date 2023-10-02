using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaioEnergia : MonoBehaviour
{
    public int danoParaDar;
    private Transform alvo;
    public float velocidadeMovimento = 10f;

    public void DefinirAlvo(Transform novoAlvo)
    {
        alvo = novoAlvo;
    }

    void Update()
    {
        if (alvo != null)
        {
            Vector3 direcaoAlvo = alvo.position - transform.position;
            float distanciaParaAlvo = direcaoAlvo.magnitude;

            // Faz com que o raio de energia siga o jogador
            if (distanciaParaAlvo > 0.1f)
            {
                Vector3 movimento = direcaoAlvo.normalized * velocidadeMovimento * Time.deltaTime;
                Quaternion rotacao = Quaternion.LookRotation(Vector3.forward, direcaoAlvo);
                transform.Translate(movimento);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerVida>().MachucarPlayer(danoParaDar);
            Destroy(this.gameObject);
        }
    }
}
