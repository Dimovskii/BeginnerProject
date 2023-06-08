using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    private GameObject _enemyPrefab;
    private Vector3 _spawnPosition;
    private int _enemyCount;
    private float _timeToSpawn = 2f;
    private float _valueX = 135f;
    private float _valueZ = 135f;

    public void Init(GameObject enemy)
    {
        _enemyPrefab = enemy;
        StartCoroutine(EnemyDrop());
    }

    private void Start() 
    {
            
    }
    
    IEnumerator EnemyDrop()
    {
        while(_enemyCount < 10)
        {
           SetPosition();
           Create();
           yield return new WaitForSeconds(_timeToSpawn);
           _enemyCount += 1;
        }
    }
     private void SetPosition()
    {
        float randomX = UnityEngine.Random.Range(-_valueX, _valueX);
        float randomZ = UnityEngine.Random.Range(-_valueZ, _valueZ);
        _spawnPosition = new Vector3(randomX, 0f, randomZ);
    }
    private void Create()
    {
        var enemy = Instantiate(_enemyPrefab, _spawnPosition, Quaternion.identity);
    }
}