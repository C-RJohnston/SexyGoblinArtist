using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer _lines;

    // Start is called before the first frame update
    void OnEnable()
    {
        GameObject brushInstance = Instantiate(GameManager.Instance.currentBrush);
        GameManager.Instance.renderOrder++;
        _lines = brushInstance.GetComponent<LineRenderer>();
        //_lines = GetComponent<LineRenderer>();
        var linePos = new Vector3(
            transform.position.x,
            transform.position.y,
            -(float)GameManager.Instance.renderOrder / 100);
        _lines.SetPosition(0, linePos);
        _lines.SetPosition(1, linePos);
        _lines.material = GameManager.Instance.currentBrush.GetComponent<Renderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        _lines.positionCount++;
        //GameManager.Instance.renderOrder++;
        //var linePos = new Vector3(
        //    transform.position.x,
        //    transform.position.y,
        //    -(float)GameManager.Instance.renderOrder / 100);
        _lines.SetPosition(_lines.positionCount - 1, transform.position);
    }

    private void OnDisable()
    {
        var brushParent = GameObject.FindWithTag("StrokeManager");
        if(_lines && brushParent) _lines.transform.parent = brushParent.transform;

    }
}

