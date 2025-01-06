using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private  RectTransform background; // Referencja do t�a
    [SerializeField] private float speed = 50f; // Pr�dko�� przesuwania
    [SerializeField] private float moveDistance = 500f; // Maksymalna odleg�o�� przesuni�cia (poza ekran)

    private Vector2 startPosition; // Pozycja pocz�tkowa
    private bool movingRight = true; // Kierunek ruchu

    private void Start()
    {
        // Zapami�taj pocz�tkow� pozycj� t�a
        startPosition = background.anchoredPosition;
    }

    private void Update()
    {
        // Oblicz now� pozycj� w zale�no�ci od kierunku ruchu
        float moveStep = speed * Time.deltaTime;
        if (movingRight)
        {
            background.anchoredPosition += new Vector2(moveStep, 0);

            // Je�li osi�gni�to maksymaln� odleg�o��, zmie� kierunek
            if (background.anchoredPosition.x >= startPosition.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            background.anchoredPosition -= new Vector2(moveStep, 0);

            // Je�li wr�cono do pocz�tkowej pozycji, zmie� kierunek
            if (background.anchoredPosition.x <= startPosition.x - moveDistance)
            {
                movingRight = true;
            }
        }
    }
}
