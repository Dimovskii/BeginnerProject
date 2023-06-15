using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] Button _continueButton;
        [SerializeField] Button _restartButton;
        [SerializeField] Button _mainMenuButton;
        private IInput _input;
        private bool _isPause = false;

        private void Awake()
        {
            _continueButton.onClick.AddListener(Hide);
            _restartButton.onClick.AddListener(RestartScene);
            _mainMenuButton.onClick.AddListener(LaodMainMenu);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Show()
        {
            gameObject.SetActive(true);
        }

        public void Init(IInput input)
        {
            _input = input;
            Sibscribe();
        }

        private void Sibscribe()
        {
            _input.OnPausePressed += Pause;
        }

        private void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void LaodMainMenu()
        {
            SceneManager.LoadScene(EnumScenes.MainMenu.ToString());
        }


        private void Pause()
        {
            if (_isPause)
            {
                Show();
                _isPause = false;
            }
            else
            {
                Hide();
                _isPause = true;
            }
        }
    }
}