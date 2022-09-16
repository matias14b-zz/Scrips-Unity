using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoALT : MonoBehaviour
{
    public Transform[] destinos;
    public bool destinosRandom;
    private int numeroDestino = 0;
    private NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = 3f;
        agent.autoBraking = false;

        irASiguientePosicion();
    }




    void Update()
    {
        if (destinosRandom == true && estaCercaDestino())
        {
            if (destinos.Length == 0)
                return;

            numeroDestino = Random.Range(0, destinos.Length);
        }

        if (estaCercaDestino())
            irASiguientePosicion();
    }

    private bool estaCercaDestino()
    {
        return agent.remainingDistance < 0.5f;
    }

    private void irASiguientePosicion()
    {
        if (destinos.Length == 0)
            return;

        agent.destination = destinos[numeroDestino].position;

        numeroDestino = (numeroDestino + 1) % destinos.Length;
    }
}

