using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer _lines;

    // Start is called before the first frame update
    void Start()
    {
        GameObject brushInstance = Instantiate(GameManager.Instance.currentBrush);
        GameManager.Instance.renderOrder++;
        _lines = brushInstance.GetComponent<LineRenderer>();
        //_lines = GetComponent<LineRenderer>();
        _lines.SetPosition(0, transform.position);
        _lines.SetPosition(1, transform.position);
        _lines.material = GameManager.Instance.currentBrush.GetComponent<Renderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        _lines.positionCount++;
        _lines.SetPosition(_lines.positionCount - 1, transform.position);
    }

    private void OnDisable()
    {
        var brushParent = GameObject.FindWithTag("StrokeManager");
        _lines.transform.parent = brushParent.transform;

    }
}

