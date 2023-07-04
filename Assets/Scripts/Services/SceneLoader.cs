using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private int gameScene;
    [SerializeField] private int startupScene;
 
    public void LoadGame()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadSceneAsync(gameScene);
    }
    public void LoadStartup()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadSceneAsync(startupScene);
    }

}