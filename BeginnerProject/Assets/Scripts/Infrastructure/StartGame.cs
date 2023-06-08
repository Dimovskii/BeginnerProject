using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _uiRoot;
    private EnemySpawner _enemySpawner;
    private PlayerSpawner _playerSpawner;

    private void Awake()
    {
        _playerSpawner = GetComponent<PlayerSpawner>();
        _enemySpawner = GetComponent<EnemySpawner>();

        GetPlayer();
        GetCamera();
        GetUIRoot();
        GEtEnemy();
    }

    private void GetPlayer()
    {
        _playerSpawner.Init(_player);
    }

    private void GetCamera()
    {
        Instantiate(_camera);
        var camera = _camera.GetComponent<CameraFollower>();
        camera.Init(_player.transform);
    }

    private void GetUIRoot()
    {
        Instantiate(_uiRoot);
    }

    private void GEtEnemy()
    {
        _enemySpawner.Init(_enemy);
    }
}
