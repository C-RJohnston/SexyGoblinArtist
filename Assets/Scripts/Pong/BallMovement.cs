using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class BallMovement : MonoBehaviour
{
    public float speed;
    public float acceleration;
    private float _height;
    private static float _speed;
    private float canvasY;

    private void Awake()
    {
        _speed = speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetPosition(1);
        var canvasObject = GameObject.FindWithTag("Canvas");
        
        if (canvasObject)
        {
            canvasY = canvasObject.transform.position.y;
            var rect = canvasObject.GetComponent<Renderer>();
            _height = rect.bounds.extents.y;
        }
        else
        {
            _height = Camera.main.orthographicSize ;
        }
    }
    private void OnEnable()
    {
        ResetPosition(1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * transform.up;
        if (transform.position.y >= _height + canvasY)
        {
            transform.position = new(
                transform.position.x,
                _height + canvasY,
                transform.position.z
            );
            transform.up = Vector3.Reflect(transform.up, Vector3.down);
            transform.rotation *= Quaternion.Euler(0,0, Random.Range(0,15));
        }
        else if (transform.position.y <= -(_height - canvasY))
        {
            transform.position = new(
                transform.position.x,
                -(_height - canvasY),
                transform.position.z);
            transform.up = Vector3.Reflect(transform.up, Vector3.up);
            transform.rotation *= Quaternion.Euler(0, 0, Random.Range(0, 15));
        }

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        transform.up = Vector3.Reflect(transform.up, other.gameObject.transform.right);
        transform.rotation *= Quaternion.Euler(0, 0, Random.Range(0, 15));
        speed += acceleration;
    }

    private void ResetPosition(int dir)
    {
        transform.position = Vector3.zero;
        transform.rotation = RandomSafeAngle(dir);
        speed = _speed;
    }

    // randomly generate an angle between x=[60,120]x∉]75,105[
    private Quaternion RandomSafeAngle(int dir)
    {
        if (Random.value > 0.5)
        {
            return Quaternion.Euler(0, 0, dir * Random.Range(60, 75));
        }
        else
        {
            return Quaternion.Euler(0, 0, dir * Random.Range(105, 120));
        }
    }
    
    
}
