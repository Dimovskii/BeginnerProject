using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _agent;
    public Transform Target { get; set; }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate() 
    {
        ChasePlayer();
    }

   private void ChasePlayer()
   {
      if(Target != null)
        {
            _agent.SetDestination(Target.transform.position);
        }
    }
}