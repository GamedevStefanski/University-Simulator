using UnityEngine;

public class HandRotation : MonoBehaviour
{
    [SerializeField] private float gameDuration = 60f; // Czas gry w sekundach
    private float elapsedTime = 0f;

    void Update()
    {
        // Aktualizacja czasu
        elapsedTime += Time.deltaTime;

        // Obliczanie k�ta obrotu
        float rotationAngle = Mathf.Lerp(0, 360, elapsedTime / gameDuration);

        // Obr�t obiektu Pivot
        transform.rotation = Quaternion.Euler(0, 0, -rotationAngle);
    }
}
