using UnityEngine;
using UnityEngine.UI;

public class ChargingBar : MonoBehaviour
{
    [SerializeField] private Slider chargeSlider; // Pasek �adunku (UI Slider)
    [SerializeField] private float decayRate = 1f; // Szybko�� opadania wska�nika
    [SerializeField] private float chargeAmount = 5f; // Ilo�� �adunku przy naci�ni�ciu spacji
    [SerializeField] private float maxCharge = 100f; // Maksymalny poziom na�adowania
    [SerializeField] private float gameDuration = 60f; // Czas trwania minigry (w sekundach)
    [SerializeField] private float gameTimer; // Licznik czasu minigry

    private bool isGameActive = true; // Czy gra jest w trakcie

    void Start()
    {
        if (chargeSlider != null)
        {
            chargeSlider.maxValue = maxCharge;
            chargeSlider.value = maxCharge / 2; // Zaczynamy od po�owy
        }

        gameTimer = gameDuration; // Ustaw licznik na czas gry
    }

    void Update()
    {
        if (!isGameActive)
            return;

        // Aktualizacja czasu gry
        gameTimer -= Time.deltaTime;
        if (gameTimer <= 0)
        {
            EndGame(true); // Gracz wygrywa, je�li czas gry min��
        }

        // Opadanie wska�nika
        if (chargeSlider != null && chargeSlider.value > 0)
        {
            chargeSlider.value -= decayRate * Time.deltaTime;
        }

        // �adowanie wska�nika przez wciskanie spacji
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (chargeSlider != null && chargeSlider.value < maxCharge)
            {
                chargeSlider.value += chargeAmount;
                chargeSlider.value = Mathf.Clamp(chargeSlider.value, 0, maxCharge);
            }
        }

        // Sprawdzenie przegranej
        if (chargeSlider != null && chargeSlider.value <= 0)
        {
            EndGame(false); // Gracz przegrywa, gdy wska�nik osi�gnie 0
        }
    }

    void EndGame(bool playerWon)
    {
        isGameActive = false;

        if (playerWon)
        {
            Debug.Log("You win! Time is up!");
        }
        else
        {
            Debug.Log("Game Over! You lost.");
        }

        // Opcjonalnie: zatrzymaj gr� (tylko do debugowania)
        // Time.timeScale = 0;
    }
}
