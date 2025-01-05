using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Transform Camera; // Referencja do kamery
    public float Sensitivity = 100f; // Czu�o�� myszy
    private float xRotation = 0f; // Rotacja w osi X (g�ra/d�)
    private Vector2 currentMouseDelta; // Aktualny ruch myszy
    private Vector2 smoothedMouseDelta; // Wyg�adzony ruch myszy
    public float SmoothTime = 0.05f; // Czas wyg�adzania ruchu myszy

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Blokowanie kursora na �rodku ekranu
        Cursor.visible = false; // Ukrycie kursora
    }

    void Update()
    {
        // Pobranie ruchu myszy
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * Sensitivity * 0.01f;

        // Wyg�adzanie ruchu myszy
        currentMouseDelta = Vector2.Lerp(currentMouseDelta, mouseDelta, 1f / SmoothTime);
        smoothedMouseDelta = Vector2.Lerp(smoothedMouseDelta, currentMouseDelta, SmoothTime);

        // Obr�t gracza w osi Y (lewo/prawo)
        transform.Rotate(Vector3.up * smoothedMouseDelta.x);

        // Obr�t kamery w osi X (g�ra/d�)
        xRotation -= smoothedMouseDelta.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Ustawienie rotacji kamery
        Camera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}