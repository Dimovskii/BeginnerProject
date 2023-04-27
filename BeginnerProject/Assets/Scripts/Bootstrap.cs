using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public static Bootstrap Instance;
    [SerializeField] private Camera _uiCamera;
    [SerializeField] private GameObject _mainMenu;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        GetUICamera();
        GetMainMenu();

    }

    private void GetUICamera()
    {
        _uiCamera = Instantiate(_uiCamera);
    }

    private void GetMainMenu()
    {
        _mainMenu = Instantiate(_mainMenu);
    }
}
