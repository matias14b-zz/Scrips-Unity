using UnityEngine;
using UnityEngine.AI;

public class MovimientoEnemigo : MonoBehaviour
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

    private bool estaCercaDeDestino(GameObject enemigo, Transform goal)
    {
        return Vector3.Distance(enemigo.transform.position, goal.position) <= 1f;
    }
}
