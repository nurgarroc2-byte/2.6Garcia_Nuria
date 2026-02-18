using UnityEngine;
using UnityEngine.AI;

public class NPCHuye : MonoBehaviour
{
    public Transform jugador;             
    public float distanciaActivacion = 5f; 
    public float distanciaHuida = 5f;      

    private NavMeshAgent agente;
    private Animator animator;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!agente.isOnNavMesh) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia <= distanciaActivacion)
        {
            // Dirección contraria al jugador
            Vector3 direccionHuida = (transform.position - jugador.position).normalized;

            // Punto de destino alejándose del jugador
            Vector3 destinoHuida = transform.position + direccionHuida * distanciaHuida;

            agente.isStopped = false;
            agente.SetDestination(destinoHuida);
        }
        else
        {
            // Se queda quieto si el jugador está lejos
            agente.isStopped = true;
        }

        // Animación
        animator.SetBool("IsMoving", agente.velocity.magnitude > 0.1f);
    }
}
