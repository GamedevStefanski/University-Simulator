using UnityEngine;

public class ClearButton : MonoBehaviour
{
    public InputOutputField[] inputFields;

    public void OnClearClick()
    {
        for (int i = inputFields.Length - 1; i >= 0; i--)
        {
            if (inputFields[i].value != -1)
            {
                inputFields[i].ClearValue();
                return;
            }
        }
    }
}
