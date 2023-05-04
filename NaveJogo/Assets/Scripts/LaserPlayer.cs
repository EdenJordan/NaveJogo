using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPlayer : MonoBehaviour
{

    public float velocidadeLaser;
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
}
