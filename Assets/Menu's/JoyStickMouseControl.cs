using UnityEngine;
using System.Runtime.InteropServices;

public class JoyStickMouseControl : MonoBehaviour
{
    // Sensitivity multiplier for joystick movement
    public float sensitivity = 10f;

    // Clamp mouse movement to screen bounds
    private int screenWidth;
    private int screenHeight;

    [DllImport("user32.dll")]
    private static extern bool SetCursorPos(int X, int Y);

    [DllImport("user32.dll")]
    private static extern bool GetCursorPos(out POINT pos);

    private struct POINT
    {
        public int X;
        public int Y;
    }

    void Start()
    {
        screenWidth = Screen.currentResolution.width;
        screenHeight = Screen.currentResolution.height;
        Cursor.visible = true;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // or "Mouse X" if mapped to joystick
        float moveY = Input.GetAxis("Vertical");   // or "Mouse Y" if mapped to joystick

        if (Mathf.Abs(moveX) > 0.1f || Mathf.Abs(moveY) > 0.1f)
        {
            POINT cursorPos;
            if (GetCursorPos(out cursorPos))
            {
                int newX = Mathf.Clamp(cursorPos.X + (int)(moveX * sensitivity), 0, screenWidth - 1);
                int newY = Mathf.Clamp(cursorPos.Y - (int)(moveY * sensitivity), 0, screenHeight - 1); // Invert Y

                SetCursorPos(newX, newY);
            }
        }
    }
}
