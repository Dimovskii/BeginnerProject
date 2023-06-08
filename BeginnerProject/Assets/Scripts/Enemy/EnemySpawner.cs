using UnityEngine;
using System.Collections;
using Factory;

public class EnemySpawner : MonoBehaviour
{
    private PrefabFactory _factory;
    private Vector3 _spawnPosition;
    private int _enemyCount;
    private float _timeToSpawn = 2f;
    private float _valueX = 135f;
    private float _valueZ = 135f;

    public void Init(PrefabFactory factory)
    {
        _factory = factory;
        StartCoroutine(EnemyDrop());
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
        _factory.Create(GameConstants.Enemy, _spawnPosition);

    }
}