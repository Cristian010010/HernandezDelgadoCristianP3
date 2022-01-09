using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTiempo : MonoBehaviour
{
    public TextMesh tiempo;
    float segundos;
    bool empezar;
    public Rigidbody2D Personaje;
    // Start is called before the first frame update
    void Start()
    {
        empezar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Personaje.velocity.x > 0) || (Input.GetKeyDown(KeyCode.Space)))
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
