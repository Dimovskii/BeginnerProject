using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float _lifeTime = 3f;
    private int _damageCount = 10;
    
    private void Awake() 
    {
        Destroy(gameObject, _lifeTime);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        collision.collider.GetComponent<Health>().TakeDamage(_damageCount);
    }
}
