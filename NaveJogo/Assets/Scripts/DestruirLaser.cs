using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirLaser : MonoBehaviour
{
    public float tempodeVida;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, tempodeVida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
