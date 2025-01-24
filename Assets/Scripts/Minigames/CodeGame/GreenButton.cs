using UnityEngine;

public class GreenButton : MonoBehaviour
{
    public InputOutputField[] inputFields;
    public InputOutputField[] outputFields;

    public void OnCheckClick()
    {
        bool isCorrect = true;

        for (int i = 0; i < inputFields.Length; i++)
        {
            outputFields[i].RevealValue(); 

            if (inputFields[i].value != outputFields[i].value)
            {
                isCorrect = false;
                outputFields[i].fieldValue.color = Color.red;
            }
            else
            {
                outputFields[i].fieldValue.color = Color.green;
            }
        }

        if (isCorrect)
        {
            Debug.Log("Konto zosta³o zhakowane poprawnie!");
        }
    }
}
