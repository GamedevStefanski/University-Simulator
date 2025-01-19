using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string mainMenuSceneName = "Credits"; // Nazwa sceny menu g��wnego

    public void LoadCredits()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}