using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMenu : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public GameObject Personaje;
    public Animator AnimatorPersonaje;
    bool derecha, EnSuelo;


    // Start is called before the first frame update
    void Start()
    {
        derecha = true;
        EnSuelo = true;
    }

    void FixedUpdate()
    {
  
    }


    // Update is called once per frame
    void Update()
    {
        AnimatorPersonaje.SetBool("TocarSuelo", EnSuelo);
        AnimatorPersonaje.SetFloat("Velocidad", rigidbody2d.velocity.x);
        AnimatorPersonaje.SetBool("Derecha", derecha);
    }
}
