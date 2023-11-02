using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FillTool : MonoBehaviour
{
    public Sprite[] images;

    private GameObject _canvas;

    private GameObject _brushParent;

    public GameObject artManager;
    // Start is called before the first frame update
    void Start()
    {
        _canvas = GameObject.FindWithTag("Canvas");
        _brushParent = GameObject.FindWithTag("StrokeManager");
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            var index = Random.Range(0, images.Length);
            artManager.GetComponent<SpriteRenderer>().sprite = images[index];
            GameManager.Instance.renderOrder++;
            Vector3 position = new(
                _canvas.transform.position.x,
                _canvas.transform.position.y,
                -(float)GameManager.Instance.renderOrder / 100
            );
            Instantiate(artManager, position, _canvas.transform.rotation,
                _brushParent.transform);

        }
    }
}
