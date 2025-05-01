using UnityEngine;
using UnityEngine.UI;

public class CursorFollowMouse : MonoBehaviour
{
    private RectTransform cursorRect;

    void Start()
    {
        cursorRect = GetComponent<RectTransform>();
        Cursor.visible = false; // ซ่อนเมาส์จริง

        // ปิด Raycast Target เพื่อไม่ให้ขัดกับ UI ปุ่มต่าง ๆ
        Image image = GetComponent<Image>();
        if (image != null)
        {
            image.raycastTarget = false;
        }
    }

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        cursorRect.position = mousePos;
    }
}
