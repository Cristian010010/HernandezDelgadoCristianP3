using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAleatorioPiedras : MonoBehaviour
{
    public Rigidbody2D Piedra;
    public float VelNegativa;
    public float VelPositiva;
    public GameObject Roca;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Piedra.AddForce(new Vector2(Random.Range(VelNegativa, VelPositiva), 0.0f));
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Muerte"))
        {
            Destroy(Roca);
        }
    }
}
