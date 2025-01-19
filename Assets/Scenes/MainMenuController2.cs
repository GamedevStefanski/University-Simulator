using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string mainMenuSceneName = "Credits"; // Nazwa sceny menu g³ównego

    public void LoadCredits()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}