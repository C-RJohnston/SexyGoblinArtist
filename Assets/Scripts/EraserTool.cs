using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraserTool : MonoBehaviour
{
    public Camera m_camera;

    public GameObject eraser;
    private LineRenderer eraserRenderer;

    public GameObject strokeParent;

    LineRenderer currentLineRenderer;
    public Collider2D canvasCollider;

    Vector2 lastPos;

    //public GameManager gameManager;

    private void Start()
    {
        eraserRenderer = eraser.GetComponent<LineRenderer>();
        eraserRenderer.startWidth = 0.1f;
        eraserRenderer.endWidth = 0.1f;

    }

    private void Update()
    {
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

        eraserRenderer.startWidth += .03f * mult;
        eraserRenderer.endWidth += .03f * mult;
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
        GameObject brushInstance = Instantiate(eraser);

        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        GameManager.Instance.renderOrder++;
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
