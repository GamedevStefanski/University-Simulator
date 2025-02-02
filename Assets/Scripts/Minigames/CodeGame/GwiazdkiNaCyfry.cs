using UnityEngine;

public class NumberButton : MonoBehaviour
{
    public InputOutput[] inputFields; 

    public void OnNumberClick(int number)
    {
        foreach (var field in inputFields)
        {
            if (field.value == -1)
            {
                field.SetValue(number);
                return;
            }
        }
    }
}