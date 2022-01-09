using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajePrincipal : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public float velocidad;
    public float altura;
    bool saltar;
    bool EnSuelo;
    public GameObject Generador1;
    public GameObject Generador2;
    public GameObject GeneradorPiedras;
    public GameObject Personaje, camara, GameOver, OverBottons;
    public Animator AnimatorPersonaje;
    bool derecha;
    float TiempoEnPlataforma;
    private Vector3 cameraPosition;
    int llaves;
    public TextMesh Llave;
    public TextMesh tiempo;
    bool empezar;
    float segundos;
    public int LimitePlataforma;
    public AudioClip Golpe, Salto, Item, SonidoGameOver;


    // Start is called before the first frame update
    void Start()
    {
        EnSuelo = true;
        derecha = true;
        llaves = 0;
        empezar = false;
        segundos = 0;
    }

    void FixedUpdate()
    {
        float movimiento = Input.GetAxis("Horizontal");
        rigidbody2d.AddForce(new Vector2(movimiento * velocidad, 0.0f));

        if (movimiento < 0)
        {
            derecha = false;
        }

        if (movimiento > 0)
        {
            derecha = true;
        }

        if (saltar)
        {
            rigidbody2d.AddForce(new Vector2(0.0f, altura));
            saltar = false;
            GetComponent<AudioSource>().clip = Salto;
            GetComponent<AudioSource>().Play();

        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Muerte"))
        {
            Time.timeScale = 0;
            GameOver.gameObject.SetActive(true);
            Personaje.gameObject.SetActive(false);
            OverBottons.gameObject.SetActive(true);
            camara.GetComponent<AudioSource>().clip = SonidoGameOver;
            camara.GetComponent<AudioSource>().loop = false;
            camara.GetComponent<AudioSource>().Play();

        }
        if (collision.gameObject.CompareTag("Llave"))
        {
            llaves = llaves + 1;
            Llave.text = llaves.ToString("F0");
            Destroy(collision.gameObject);
            segundos = segundos + 100;
            GetComponent<AudioSource>().clip = Item;
            GetComponent<AudioSource>().Play();
        }
        if (collision.gameObject.CompareTag("Roca"))
        {
            GetComponent<AudioSource>().clip = Golpe;
            GetComponent<AudioSource>().Play();
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataformas"))
        {
            EnSuelo = true;
            TiempoEnPlataforma = TiempoEnPlataforma+Time.deltaTime;
            if (TiempoEnPlataforma>LimitePlataforma)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataformas"))
        {
            EnSuelo = false;
            TiempoEnPlataforma = 0;
        }
    }


    // Update is called once per frame
    void Update()
    {
        AnimatorPersonaje.SetBool("TocarSuelo", EnSuelo);
        AnimatorPersonaje.SetFloat("Velocidad", rigidbody2d.velocity.x);
        AnimatorPersonaje.SetBool("Derecha", derecha);
        if ((Input.GetKeyDown(KeyCode.Space)) && (EnSuelo == true))
        {
            saltar = true;
        }
        cameraPosition = camara.transform.position;
        if ((rigidbody2d.velocity.x > 0) || (Input.GetKeyDown(KeyCode.Space)))
        {
            empezar = true;
        }
        if (empezar)
        {
            segundos = segundos + Time.deltaTime;
            tiempo.text = segundos.ToString("F0");
        }
    }
}
