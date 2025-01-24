using UnityEngine;

public class paperball : MonoBehaviour
{
    public GameObject paperPrefab; // Prefab kulki papieru
    public Transform throwPoint;   // Punkt startowy rzutu
    public float maxThrowForce = 15f; // Maksymalna si�a rzutu
    public Camera playerCamera;    // Kamera gracza, u�ywana do celowania

    private float currentForce = 0f; // Aktualna si�a rzutu

    void Update()
    {
        // �adowanie si�y rzutu
        if (Input.GetKey(KeyCode.Space))
        {
            currentForce += Time.deltaTime * 10; // Przytrzymanie klawisza zwi�ksza si��
            currentForce = Mathf.Clamp(currentForce, 0, maxThrowForce); // Ograniczenie maksymalnej si�y
        }

        // Rzut kulk�
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ThrowPaper();
        }
    }

    void ThrowPaper()
    {
        // Tworzenie kulki papieru w punkcie startowym
        GameObject paper = Instantiate(paperPrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = paper.GetComponent<Rigidbody>();

        // Wyliczanie kierunku rzutu (w oparciu o kamer� gracza)
        Vector3 throwDirection = GetThrowDirection();

        // Nadanie si�y rzutu
        rb.AddForce(throwDirection * currentForce, ForceMode.Impulse);

        // Reset si�y po rzucie
        currentForce = 0;
    }

    Vector3 GetThrowDirection()
    {
        // Celowanie w przestrzeni 3D za pomoc� kamery
        Ray cameraRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Je�li kamera "widzi" kosz lub inn� powierzchni�, kierujemy rzut w to miejsce
        if (Physics.Raycast(cameraRay, out hit))
        {
            return (hit.point - throwPoint.position).normalized; // Kierunek do punktu trafienia
        }
        else
        {
            return throwPoint.forward; // Domy�lny kierunek (przed siebie)
        }
    }
}

