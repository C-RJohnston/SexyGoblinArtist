using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private float _height;
    private float _width;
    private float _canvasY;
    public bool left;
    // Start is called before the first frame update
    void Start()
    {
        var canvasObject = GameObject.FindWithTag("Canvas");
        if (canvasObject)
        {
            _canvasY = canvasObject.transform.position.y;
            var rect = canvasObject.GetComponent<Renderer>();
            _height = rect.bounds.extents.y - (transform.localScale.y / 2);
            _width = rect.bounds.extents.x;
        }
        else
        {
            _height = Camera.main.orthographicSize - (transform.localScale.y / 2);
            _width = _height * Camera.main.aspect;
        }

        var x = left ? -_width : _width;
        transform.position = new(x, 0, transform.position.z);

    }

    private void OnEnable()
    {
        var x = left ? -_width : _width;
        transform.position = new(x, 0, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveUp(float amount)
    {
        var newY = Mathf.Clamp(transform.position.y + amount,
            -(_height - _canvasY), (_height + _canvasY));
        transform.position = new Vector3(
            transform.position.x,
            newY,
            transform.position.z);
        
    }
}
