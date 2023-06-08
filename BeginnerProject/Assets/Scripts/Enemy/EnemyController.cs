using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private GameObject _player;
    private NavMeshAgent _agent;
    private const string _tagPlayer = "Player"; 

   private void Awake() 
   {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag(_tagPlayer);
   }

    private void Update() 
    {
        ChasePlayer();
    }

   private void ChasePlayer()
   {
      _agent.SetDestination(_player.transform.position);
   }
}