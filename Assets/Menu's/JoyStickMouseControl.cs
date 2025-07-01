using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.EventSystems;

public class JoyStickMouseControl : MonoBehaviour
{
    public float sensitivity = 10f;

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
        MoveMouseWithJoystick();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SimulateClick();
        }
    }

    void MoveMouseWithJoystick()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

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

    void SimulateClick()
    {
        // Convert screen-space mouse position to world-space ray
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Try to interact with a component
            hit.collider.gameObject.SendMessage("OnMouseDown", SendMessageOptions.DontRequireReceiver);
        }

        // Optional: handle UI button clicks
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = mousePos
        };

        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (var result in results)
        {
            ExecuteEvents.Execute(result.gameObject, pointerData, ExecuteEvents.pointerClickHandler);
        }
    }
}
