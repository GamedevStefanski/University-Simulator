using UnityEngine;
using UnityEngine.UI;

public class InputOutputField : MonoBehaviour
{
    public Text fieldValue;
    public int value = -1;

    public void SetValue(int newValue)
    {
        value = newValue;
        fieldValue.text = newValue >= 0 ? newValue.ToString() : "*";
        fieldValue.color = newValue >= 0 ? Color.black : Color.gray;
    }

    public void ClearValue()
    {
        value = -1;
        fieldValue.text = "*";
        fieldValue.color = Color.gray;
    }
}