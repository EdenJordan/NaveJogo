using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioInfinito : MonoBehaviour
{

    public float velocidadeCenario;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarCenario();
    }

    private void MovimentarCenario()
    {
        Vector2 deslocamentoDoCenario = new Vector2(Time.time * velocidadeCenario, 0f);
        GetComponent<Renderer>().material.mainTextureOffset = deslocamentoDoCenario;
    }
}
