using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            player.TakeDamage(10);
        }
    }
}