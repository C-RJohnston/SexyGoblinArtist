using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlySwatterScript : MonoBehaviour
{

    [SerializeField] private GameObject flySpawner;
    [SerializeField] private Texture2D cursorTexture;
    
    [SerializeField] private Texture2D cursorActiveTexture;


    private void OnEnable()
    {
        flySpawner.SetActive(true);
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnDisable()
    {
        if (flySpawner) flySpawner.SetActive(false);
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
