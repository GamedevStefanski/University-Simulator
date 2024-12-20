using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Transform Camera;
    public float Sensitivity;
    float xRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * MouseX);

        xRotation = MouseY;
        xRotation = Mathf.Clamp(xRotation, 0, 0);
        Camera.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}