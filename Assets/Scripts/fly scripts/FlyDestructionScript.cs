using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyDestructionScript : MonoBehaviour
{
    [SerializeField] private GameObject splat;
    private GameObject _brushParent;
    private GameManager _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _brushParent = GameObject.FindWithTag("StrokeManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            /*
             * splat animation
             */
            
            /*
             * draw splat
             */
            Transform t = transform;
            var _gameManager = GameObject.Find("GameManager");
            Instantiate(splat, t.position, t.rotation, _brushParent.transform);

            /*
             * destroy fly
             */
            Destroy(this.gameObject);
        }
    }
}
