using JetBrains.Annotations;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    [SerializeField] [CanBeNull] private Texture2D cursorTexture;
    
    [SerializeField] [CanBeNull] private Texture2D cursorActiveTexture;

    private void OnEnable()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnDisable()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Cursor.SetCursor(cursorActiveTexture, Vector2.zero, CursorMode.ForceSoftware);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
