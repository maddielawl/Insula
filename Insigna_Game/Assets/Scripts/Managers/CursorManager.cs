using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    #region Singlton:Profile

    public static CursorManager Instance;
    public bool cursorState;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

    }
    #endregion

    public Image rend;
    public Sprite cursor;
    public Sprite takeCursor;
    public Sprite grabCursor;
    public float horizontalOffset;
    public float verticalOffset;
    private Vector2 cursorPos;
    void Start()
    {
        UnityEngine.Cursor.visible = false;
        rend = GetComponent<Image>();
        cursorState = true;
    }

    // Update is called once per frame
    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x - horizontalOffset, Input.mousePosition.y - verticalOffset));
        transform.position = cursorPos;
    }
}
