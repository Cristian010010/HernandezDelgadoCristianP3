using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoPlataformas : MonoBehaviour
{
    public GameObject[] Plataformas;
    public float TiempoMin;
    public float TiempoMax;
    public Rigidbody2D Personaje;
    int i;

    // Start is called before the first frame update
    void Start()
        {

        }


    void Update()
    {
        if (((Personaje.velocity.x > 0) || (Input.GetKeyDown(KeyCode.Space))) && (i<1))
        {
            GenerarPlataformas();
            i += 1;
        }
    }


    void GenerarPlataformas()
    {
        Instantiate(Plataformas[Random.Range(0, Plataformas.Length)], transform.position, Quaternion.identity);
        Invoke("GenerarPlataformas", Random.Range(TiempoMin, TiempoMax));
    }

    // Update is called once per frame
 
}
