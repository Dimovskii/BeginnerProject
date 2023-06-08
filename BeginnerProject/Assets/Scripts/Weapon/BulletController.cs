using Interfaces;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float _lifeTime = 3f;
    private int _damageAmount;
    private int _speed;

    public void Init(int speed, int damage)
    {
        _speed = speed;
        _damageAmount = damage;
        Destroy(gameObject, _lifeTime);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        IDamageable damageable = collision.transform.GetComponent<IDamageable>();
        damageable?.TakeDamage(_damageAmount);
    }
}
