using UnityEngine;

public class ExitConfirmationManager : MonoBehaviour
{
    public GameObject confirmationPanel; // Panel z potwierdzeniem
    public GameObject mainMenuPanel;    // Panel g��wnego menu (je�li istnieje)

    // Metoda do pokazania panelu potwierdzenia
    public void ShowConfirmation()
    {
        Debug.Log("ShowConfirmation wywo�ane");
       
        confirmationPanel.SetActive(true);
       
    }

    // Metoda do ukrycia panelu potwierdzenia
    public void HideConfirmation()
    {

        confirmationPanel.SetActive(false);
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true); // Poka� menu, je�li by�o ukryte
        }
    }

    // Metoda do wyj�cia z gry
    public void QuitGame()
    {
        Debug.Log("Exiting the game..."); // Dzia�a tylko w buildzie gry
        Application.Quit();
    }
}
