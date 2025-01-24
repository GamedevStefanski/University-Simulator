using UnityEngine;
using TMPro;

public class InputOutputField : MonoBehaviour
{
    public TMP_Text fieldValue; 
    public int value = -1;      

    public void SetValue(int newValue, bool hideValue = false)
    {
        value = newValue;
        fieldValue.text = hideValue ? "*" : newValue.ToString();
        fieldValue.color = hideValue ? Color.black : Color.gray;
    }

    public void ClearValue() 
    {
        value = -1;
        fieldValue.text = "*";
        fieldValue.color = Color.gray;
    }

    public void RevealValue() 
    {
        fieldValue.text = value.ToString();
    }
}
