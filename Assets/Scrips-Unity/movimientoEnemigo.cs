using UnityEngine;
using UnityEngine.AI;

public class movimientoEnemigo : MonoBehaviour
{
    public GameObject enemigo;
    public Transform[] goals;
    private int destinoActual = 0;

    public void Update()
    {
        Transform goal = goals[destinoActual];
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        if (estaCercaDeDestino(enemigo, goal))
        {
            destinoActual =  (destinoActual + 1) % goals.Length;
        }
       
    }
}
