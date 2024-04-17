using UnityEngine;
using System.Runtime.InteropServices;

public class CameraController : MonoBehaviour
{
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);
    float rotationX = 0;
    float rotationY = 0;
    float mouseX;
    float mouseY;
    public float sensitivity = 1f; // коэффициент чувствительности мыши

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        //Vector2 center = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Vector2 center = new Vector2(960, 540);
        SetCursorPos((int)center[0], (int)center[1]);
        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        transform.rotation = Quaternion.Euler(mouseX, mouseY, 0f);
    }
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationY += mouseX;
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}