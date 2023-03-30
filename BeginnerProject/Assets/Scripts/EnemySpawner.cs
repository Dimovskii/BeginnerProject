using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private Vector3 _spawnPosition;
    private int _enemyCount;
    private float _timeToSpawn = 2f;
    private float _valueX = 135f;
    private float _valueZ = 135f;

    private void Start() 
    {
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
        Debug.Log(_spawnPosition);
    }
    private void Create()
    {
        var enemy = Instantiate(_enemyPrefab, _spawnPosition, Quaternion.identity);
    }
}