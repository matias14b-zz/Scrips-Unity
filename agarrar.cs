using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrar : MonoBehaviour
{
    public float rangoDeAgarre;
    public bool esAgarrable = true;
    public GameObject item;
    public GameObject itemTemporal;
    public GameObject player;
    public bool estaSiendoSostenido = false;

    KeyCode botonAgarrar; 
    Rigidbody itemRigidbody;
    Vector3 posicionObjeto;
    float distancia;
    private void Awake()
    {
        itemRigidbody = item.GetComponent<Rigidbody>();
       botonAgarrar = obtenerBotonAgarrarDePlayer();
    }
    void Update()
    {
        distancia = obtenerDistancia();
        soltarObjetoAlSuperarRango(distancia, rangoDeAgarre);
        
        if (estaSiendoSostenido)
        {
            itemRigidbody.velocity = Vector3.zero;
            itemRigidbody.freezeRotation = true;
            itemRigidbody.detectCollisions = false;
            itemRigidbody.position = itemTemporal.transform.position;
        }
        else
        {
            posicionObjeto = item.transform.position;
            itemRigidbody.useGravity = true;
            itemRigidbody.freezeRotation = false;
            itemRigidbody.detectCollisions = true;
            item.transform.position = posicionObjeto;
         
        }

        if (Input.GetKeyDown(botonAgarrar))
        {
            if (distancia <= rangoDeAgarre)
            {
                estaSiendoSostenido = true;
                itemRigidbody.useGravity = false;
                itemRigidbody.detectCollisions = true;
            }
        }

        if (Input.GetKeyUp(botonAgarrar))
        {
            estaSiendoSostenido = false;
        }
    }

    private float obtenerDistancia()
    {
        return Vector3.Distance(item.transform.position, itemTemporal.transform.position);
    }

    private void soltarObjetoAlSuperarRango(float distancia, float rangoDeAgarre)
    {
        if (distancia >= rangoDeAgarre)
        {
            estaSiendoSostenido = false;
        }
    }

    private KeyCode obtenerBotonAgarrarDePlayer()
    {
        return player.GetComponent<MovimientoControlable>().botonAgarrar;
    }
}
