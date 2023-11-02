using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTool : MonoBehaviour
{
    public Camera m_camera;

    public LineRenderer[] brushLines;

    public GameObject strokeParent;
    
    LineRenderer currentLineRenderer;
    public Collider2D canvasCollider;

    Vector2 lastPos;

    public Color[] cursorColors;
    public GameObject cursor;
    public SpriteRenderer cursorRenderer;
    private Vector3 cursorSize = new Vector3(1f,1f,1f);

    private void Start()
    {
        foreach (LineRenderer lineRenderer in brushLines)
        {
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
        }
        cursorRenderer = cursor.GetComponent<SpriteRenderer>();
        cursorRenderer.color = cursorColors[0];
        cursorSize = cursor.transform.localScale;
        Cursor.visible = false;
    }

    
    private void OnDisable()
    {
        foreach (LineRenderer lineRenderer in brushLines)
        {
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
        }
        cursor.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Cursor.visible = true;
    }

    private void Update()
    {
        var mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -2;
        cursor.transform.position = mousePos;

        var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (canvasCollider.bounds.IntersectRay(mouseRay))
        {
            Drawing();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeSize(1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeSize(-1);
        }
        
    }

    public void ChangeSize(int mult)
    {
        
        foreach (LineRenderer lineRenderer in brushLines)
        {
            lineRenderer.startWidth += 0.03f * mult;
            lineRenderer.endWidth += 0.03f * mult;

            cursorSize.x += (0.007f * mult) ;
            cursorSize.y += (0.007f * mult) ;
            cursor.transform.localScale = cursorSize;
        }
    }
    

    void Drawing()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            PointToMousePos();
        }
        else
        {
            currentLineRenderer = null;
        }
    }

    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(GameManager.Instance.currentBrush);
        GameManager.Instance.renderOrder++;
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        //currentLineRenderer.sortingOrder = GameManager.Instance.renderOrder;
        currentLineRenderer.transform.parent = strokeParent.transform;

        //because you gotta have 2 points to start a line renderer, 
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 linePos = new Vector3(mousePos.x, mousePos.y,
            -(float)GameManager.Instance.renderOrder / 100);
        currentLineRenderer.SetPosition(0, linePos);
        currentLineRenderer.SetPosition(1, linePos);

    }

    void AddAPoint(Vector3 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    void PointToMousePos()
    {
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 linePos = new Vector3(mousePos.x, mousePos.y,
            -(float)GameManager.Instance.renderOrder / 100);
        if (lastPos != mousePos)
        {
            AddAPoint(linePos);
            lastPos = mousePos;
        }
    }
}
