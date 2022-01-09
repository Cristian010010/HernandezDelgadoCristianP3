using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoFondo : MonoBehaviour
{
    public Renderer RendererFondo;
    public float velocidad;
    public Rigidbody2D Personaje;
    bool PersonajeEnMovimiento;
    // Start is called before the first frame update
    void Start()
    {
        PersonajeEnMovimiento = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Personaje.velocity.x > 0) || (Input.GetKeyDown(KeyCode.Space)))
        {
            PersonajeEnMovimiento = true;
        }

        if (PersonajeEnMovimiento)
        {
            RendererFondo.material.mainTextureOffset = new Vector2(0.0f, Time.time * velocidad);
        }
    }
}
