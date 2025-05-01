using UnityEngine;
using UnityEngine.UI;

public class CursorFollowMouse : MonoBehaviour
{
    private RectTransform cursorRect;

    void Start()
    {
        cursorRect = GetComponent<RectTransform>();
        Cursor.visible = false; 

        
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
