using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PaddleMovement))]
public class PaddleMovementInput : MonoBehaviour
{
    private PaddleMovement _paddleMovement;
    public float speed;
    private void Awake()
    {
        _paddleMovement = GetComponent<PaddleMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            _paddleMovement.MoveUp(speed * Time.deltaTime * -1f);
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            _paddleMovement.MoveUp(speed * Time.deltaTime);
        }
    }
}
