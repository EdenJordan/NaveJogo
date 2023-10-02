using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserPlayer : MonoBehaviour
{
    public bool laserlongoouSupertiro;
        
    public float velocidadeLaser;

    public float danoParaDar;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, -90);
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarLaser();
        
    }

    private void MovimentarLaser()
    {
        transform.Translate(Vector3.up * velocidadeLaser * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (laserlongoouSupertiro)
            {
                other.gameObject.GetComponent<Inimigos>().MachucarInimigo(danoParaDar);
            }
            else
            {
                other.gameObject.GetComponent<Inimigos>().MachucarInimigo(danoParaDar);
                Destroy(this.gameObject);
            }
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            if (laserlongoouSupertiro)
            {
                other.gameObject.GetComponent<NaveMae>().MachucarInimigo(danoParaDar);
            }
            else
            {
                other.gameObject.GetComponent<NaveMae>().MachucarInimigo(danoParaDar);
                Destroy(this.gameObject);
            }
        }
        

    }
    
    
    
}
