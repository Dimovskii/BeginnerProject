using UnityEngine;

namespace Assets.Scripts
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private GameObject _hud;
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _gameOverScren;

        private void Awake()
        {
            var newHud = Instantiate(_hud);
            newHud.transform.SetParent(gameObject.transform);

            var newPauseMenu = Instantiate(_pauseMenu);
            newPauseMenu.transform.SetParent(gameObject.transform);

            var newGameOverScreen = Instantiate(_gameOverScren);
            newGameOverScreen.transform.SetParent(gameObject.transform);
        }
    }
}