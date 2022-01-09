using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComportamientoMenu : MonoBehaviour
{
    public GameObject comenzar, principiante, avanzado, experto, salir;
    public AudioClip SonidoItem;
    // Start is called before the first frame update
    void Start()
    {
        principiante.gameObject.SetActive(false);
        avanzado.gameObject.SetActive(false);
        experto.gameObject.SetActive(false);
    }

    public void Comenzar()
    {
        comenzar.gameObject.SetActive(false);
        salir.gameObject.SetActive(false);
        principiante.gameObject.SetActive(true);
        avanzado.gameObject.SetActive(true);
        experto.gameObject.SetActive(true);
        GetComponent<AudioSource>().clip = SonidoItem;
        GetComponent<AudioSource>().Play();

    }

    public void BotonNivel1()
    {
        GetComponent<AudioSource>().clip = SonidoItem;
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Principiante");

    }

    public void BotonNivel2()
    {
        GetComponent<AudioSource>().clip = SonidoItem;
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Avanzado");

    }

    public void BotonNivel3()
    {
        GetComponent<AudioSource>().clip = SonidoItem;
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Experto");

    }

    public void Salir()
    {
        GetComponent<AudioSource>().clip = SonidoItem;
        GetComponent<AudioSource>().Play();
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
