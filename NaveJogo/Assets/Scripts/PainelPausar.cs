using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelPausar : MonoBehaviour
{
    public Transform PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenu.gameObject.activeSelf)
            {
                PauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                PauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void Continuarjogo()
    {
        PauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
