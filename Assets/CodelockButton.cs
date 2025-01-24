using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class CodelockButton : MonoBehaviour
{
    [SerializeField] List<GameObject> InputGrids = new List<GameObject>();
    [SerializeField] List<GameObject> OutputGrids = new List<GameObject>();
    [SerializeField] private int currentNumber = 0;
    [SerializeField] GameObject MapPlayer;
    [SerializeField] GameObject Minigame;
    [SerializeField] private int correct = 0;

    public void NumberButton(int number)
    {
        InputGrids[currentNumber].gameObject.GetComponent<CodelockNumber>().number = number;
        InputGrids[currentNumber].gameObject.GetComponent<TMP_Text>().text = number.ToString();
        if (currentNumber < InputGrids.Count -1) 
            currentNumber++;
    }

    public void DeleteNumber()
    {
        InputGrids[currentNumber].gameObject.GetComponent<CodelockNumber>().number = -1;

        if (currentNumber > 0)
            currentNumber--;
    }
    public void CheckNumbers()
    {
        for (int i = 0; i < InputGrids.Count; i++)
        {
            

            if (InputGrids[i].gameObject.GetComponent<CodelockNumber>().number == OutputGrids[i].gameObject.GetComponent<CodelockNumber>().number)
            {
                OutputGrids[i].gameObject.GetComponent<TMP_Text>().color = Color.green;
                OutputGrids[i].gameObject.GetComponent<TMP_Text>().text = OutputGrids[i].gameObject.GetComponent<CodelockNumber>().number.ToString();
            }
            else
            {
                OutputGrids[i].gameObject.GetComponent<TMP_Text>().color = Color.red;
            } 

                InputGrids[i].gameObject.GetComponent<TMP_Text>().color = Color.white;

            if (OutputGrids[i].gameObject.GetComponent<TMP_Text>().text != "*")
                correct++;
        }

        if (correct == OutputGrids.Count)
            Endgame();
        else
            correct = 0;

        currentNumber = 0;
    }
    void Update()
    {
        
        InputGrids[currentNumber].gameObject.GetComponent<TMP_Text>().color = Color.yellow;

        for (int i = 0; i < InputGrids.Count; i++)
        {
            if (InputGrids[i].gameObject.GetComponent<CodelockNumber>().number == -1)
            {
                InputGrids[i].gameObject.GetComponent<TMP_Text>().text = "*";
            }
        }
        
    }

    private void Start()
    {
        for (int i = 0; i < OutputGrids.Count; i++)
        {
            OutputGrids[i].gameObject.GetComponent<CodelockNumber>().number = Random.Range(0, 9);
        }
    }

    private void Endgame()
    {
        MapPlayer.SetActive(true);
        Minigame.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}   



