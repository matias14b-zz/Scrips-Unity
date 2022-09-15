using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Transform[] destinos;
    public GameObject player;
    private int destinoActual = 0;
    private float velocidad = 2f;

    private void Update()
    {
        Transform destino = destinos[destinoActual];
        if (estaEnDestino(destino))
        {
            destinoActual = nuevoDestino(destinoActual, destinos);
        }
        else
        {
            transform.position = moverHacia(destino);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
         if(other.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }

    private Boolean estaEnDestino(Transform  destino)
    {
        return Vector3.Distance(transform.position, destino.position) < 0.01f;
    }

    private int nuevoDestino(int destinoActual, Transform[] destinos)
    {
       return (destinoActual + 1) % destinos.Length;
    }

    private Vector3 moverHacia(Transform destino)
    {
        return Vector3.MoveTowards(transform.position, destino.position, velocidad * Time.deltaTime);
    }
}
