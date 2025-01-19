using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController2 : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu"; // Nazwa sceny menu g³ównego

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
