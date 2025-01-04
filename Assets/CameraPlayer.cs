using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Transform Camera; // Referencja do kamery
    public float Sensitivity = 100f; // Czu�o�� myszy
    private float xRotation = 0f; // Rotacja w osi X (g�ra/d�)

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Blokowanie kursora na �rodku ekranu
        Cursor.visible = false; // Ukrycie kursora
    }

    void Update()
    {
        // Pobranie ruchu myszy
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        // Obr�t gracza w osi Y (lewo/prawo)
        transform.Rotate(Vector3.up * mouseX);

        // Obr�t kamery w osi X (g�ra/d�)
        xRotation -= mouseY; // Ujemne, poniewa� ruch myszy w g�r� powoduje spadek k�ta
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Ograniczenie k�ta (patrzenie tylko w g�r� i w d� w zakresie 90�)

        // Ustawienie rotacji kamery
        Camera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
