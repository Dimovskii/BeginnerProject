using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playGame;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _exitGame;

    private void Awake()
    {
        _playGame.onClick.AddListener(StartGame);
        _settings.onClick.AddListener(SettingsGame);
        _exitGame.onClick.AddListener(ExitGame);
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(EnumScenes.GameSession.ToString());
    }

    private void SettingsGame()
    {

    }

    private void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit App");
    }
}