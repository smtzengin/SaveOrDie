using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public float xRotationLimit = 90f;
    public float yRotationLimit = 45f;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -yRotationLimit, yRotationLimit);

        xRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -xRotationLimit, xRotationLimit);

        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
