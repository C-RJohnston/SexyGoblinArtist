using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTool : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;
    public GameObject strokeParent;


    LineRenderer currentLineRenderer;
    public Collider2D canvasCollider;


    Vector2 lastPos;

    private void Update()
    {
        /*
         * var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (canvasCollider.bounds.IntersectRay(mouseRay))
        {
            Drawing();
        }
        */
        Drawing();
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
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        currentLineRenderer.transform.parent = strokeParent.transform;

        //because you gotta have 2 points to start a line renderer, 
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

    }

    void AddAPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    void PointToMousePos()
    {
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        if (lastPos != mousePos)
        {
            AddAPoint(mousePos);
            lastPos = mousePos;
        }
    }
}
