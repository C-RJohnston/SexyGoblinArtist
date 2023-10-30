using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTool : MonoBehaviour
{
    public Camera m_camera;

    public List<GameObject> brushList;
    public LineRenderer[] brushLines;
    private GameObject currentBrush;
    private int brushOrder = 0;

    public GameObject strokeParent;
    

    LineRenderer currentLineRenderer;
    public Collider2D canvasCollider;

    //public GameManager gameManager;

    Vector2 lastPos;
    private void Start()
    {
        currentBrush = brushList[0];
        
        foreach (LineRenderer lineRenderer in brushLines)
        {
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
        }
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

        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeBrush();
        }
                
    }

    public void ChangeSize(int mult)
    {
        
        foreach (LineRenderer lineRenderer in brushLines)
        {
            lineRenderer.startWidth += 0.03f * mult;
            lineRenderer.endWidth += 0.03f * mult;
        }
    }

    public void ChangeBrush()
    {
        brushOrder++;
        if (brushOrder < brushList.Count)
        {
            currentBrush = brushList[brushOrder];
        }
        else
        {
            brushOrder = 0;
            currentBrush = brushList[brushOrder];
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
        GameObject brushInstance = Instantiate(currentBrush);
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
