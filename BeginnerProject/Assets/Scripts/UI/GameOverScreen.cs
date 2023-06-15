using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;
    private IPlayerHealth _playerHealth;

    public void Init(IPlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;
        Sibscribe();
    }

    private void Awake()
    {
        _restartButton.onClick.AddListener(Restart);
        _mainMenuButton.onClick.AddListener(LoadMainMenu);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(EnumScenes.MainMenu.ToString()); ;
    }

    private void Sibscribe()
    {
        _playerHealth.OnDead += ShowGameOverScreen;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowGameOverScreen()
    {
        gameObject.SetActive(true);
    }
}