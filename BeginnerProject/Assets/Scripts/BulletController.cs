using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float _lifeTime = 5f;
    private void Start() 
    {
        Destroy(gameObject, _lifeTime);    
    }
}
