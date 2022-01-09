using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camara3 : MonoBehaviour
{
    public float velocidad;
    bool empezar;
    public Rigidbody2D Personaje;
    public GameObject Pause, personaje, PauseBottons, hud;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        empezar = false;
    }

    void Update()
    {
        if ((Personaje.velocity.x>0)||(Input.GetKeyDown(KeyCode.Space)))
        {
            empezar = true;
        }

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (empezar)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + velocidad, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Time.timeScale = 0;
            empezar = false;
            Pause.gameObject.SetActive(true);
            personaje.gameObject.SetActive(false);
            PauseBottons.gameObject.SetActive(true);

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            hud.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            hud.gameObject.SetActive(false);
        }

    }
    public void Continuar()
    {
        Time.timeScale = 1;
        empezar = true;
        Pause.gameObject.SetActive(false);
        personaje.gameObject.SetActive(true);
        PauseBottons.gameObject.SetActive(false);
    }
    public void Salir()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void Reintentar()
    {
        SceneManager.LoadScene("Experto");
    }
}
