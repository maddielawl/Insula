using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    #region Singlton:Profile

    public static CursorManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    public Image rend;
    public Sprite Cursor;
    public float horizontalOffset;
    public float verticalOffset;
    private Vector2 cursorPos;
    void Start()
    {
        UnityEngine.Cursor.visible = false;
        rend = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x - horizontalOffset, Input.mousePosition.y - verticalOffset));
        transform.position = cursorPos;
    }
}
