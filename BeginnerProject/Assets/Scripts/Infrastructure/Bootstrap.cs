using UnityEngine;
using UnityEngine.SceneManagement;      

public class Bootstrap : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadSceneAsync(EnumScenes.MainMenu.ToString());
        DontDestroyOnLoad(gameObject);  
    }
}
