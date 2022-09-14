using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;


public class MovimientoControlable : MonoBehaviour
{
    public float velocidadMovimiento;
    public KeyCode botonAgarrar;
    public float velocidadSalto = 50;
    private bool estaEnElPiso = true;
    
    private Rigidbody selfRigidbody;

    void Start()
    {
        selfRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        moverPersonaje(velocidadMovimiento);
    }
    private void moverPersonaje(float velocidadMovimiento)
    {
        mover(velocidadMovimiento);
        saltar();
    }
    private void mover(float velocidadMovimiento)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        selfRigidbody.velocity = new Vector3(horizontalInput * velocidadMovimiento, selfRigidbody.velocity.y, verticalInput * velocidadMovimiento);
    }
    private void saltar()
    {
        if (Input.GetButtonDown("saltar") && estaEnElPiso)
        {
            selfRigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            estaEnElPiso = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            estaEnElPiso = true;
        }
    }
}