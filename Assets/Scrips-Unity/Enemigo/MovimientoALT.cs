using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoALT : MonoBehaviour
{
    public Transform[] destinos;
    private int numeroDestino = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        irASiguientePosicion();
    }


    void irASiguientePosicion()
    {
        if (destinos.Length == 0)
            return;

        agent.destination = destinos[numeroDestino].position;

        numeroDestino = (numeroDestino + 1) % destinos.Length;
    }

    void Update()
    {

        if (estaCercaDestino())
            irASiguientePosicion();
    }

    private bool estaCercaDestino()
    {
        return agent.remainingDistance < 0.5f;
    }
}

