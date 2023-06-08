using Factory;
using System.Collections.Generic;
using UnityEngine;

public class MenuLoader : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabs;
    private GameObjectFactory _factory;
    private void Awake()
    {
        _factory = new GameObjectFactory();

        foreach (GameObject prefab in _prefabs) 
        {
            _factory.Create(prefab);
        }
    }
}
