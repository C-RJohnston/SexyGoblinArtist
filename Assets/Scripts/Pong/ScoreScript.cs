using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private GameObject _ball;

    private float _width;
    // Start is called before the first frame update
    void Start()
    {
        var canvasObject = GameObject.FindWithTag("Canvas");
        
        if (canvasObject)
        {
            var rect = canvasObject.GetComponent<Renderer>();
            _width = rect.bounds.extents.x;
        }
        else
        {
            var height = Camera.main.orthographicSize ;
            _width = height * Camera.main.aspect;
        }
    }

    private void OnEnable()
    {
        _ball = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (_ball.transform.position.x >= _width)
        {
            gameObject.SetActive(false);
        }
        else if (_ball.transform.position.x <= -_width)
        {
            gameObject.SetActive(false);
        }
    }
}
