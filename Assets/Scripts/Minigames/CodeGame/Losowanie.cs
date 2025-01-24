using UnityEngine;

public class Losowanie : MonoBehaviour
{
    public InputOutputField[] outputFields; 

    void Start()
    {
        foreach (var field in outputFields)
        {
            int randomValue = Random.Range(0, 10); 
            field.SetValue(randomValue, true); 
        }
    }
}

