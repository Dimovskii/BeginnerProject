using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] GameObject _weaponUI;
    [SerializeField] GameObject _bulletUI;
    [SerializeField] GameObject _healthBar;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowGameOverScreen()
    {
        gameObject.SetActive(true);
        _weaponUI.SetActive(false);
        _bulletUI.SetActive(false);
        _healthBar.SetActive(false);
    }
}