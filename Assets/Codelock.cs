using System;
using System.Collections.Generic;
using UnityEngine;

public class Codelock : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    List<GameObject> InputGrids = new List<GameObject>();
    List<GameObject> OutputGrids = new List<GameObject>();

    public void CheckNumbers()
    {
        for(int i = 0; i < InputGrids.Count; i++)
        {
            if(InputGrids[i].gameObject.GetComponent<CodelockNumber>().number == (OutputGrids[i].gameObject.GetComponent<CodelockNumber>().number))
            {
                Debug.Log("One number is correct!");
            }
        }
    }
}
