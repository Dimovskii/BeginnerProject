using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float _lifeTime = 3f;
    private int _damageCount = 10;
    private 
    WeaponManager _weaponManager;
    
    private void Awake() 
    {
        Destroy(gameObject, _lifeTime);
    }

    private void Update() 
    {
       Debug.Log(_damageCount);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
        {
            enemy.TakeDamage(_damageCount);
        }
    }
}
