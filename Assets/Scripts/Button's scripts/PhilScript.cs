using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhilScript : MonoBehaviour
{
    //public Animator animator;
    public Vector3 start;
    public Vector3 end;
    public float speed;
    public float waitTime;

    private Vector3 _target;
    private float _timeElapsed;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        transform.position = start;
        _target = end;
        _timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target,
            speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, _target) < 0.5 )
        {
            if (_timeElapsed >= waitTime)
            {
                _target = start;
            }
            else
            {
                transform.position = end;
                _timeElapsed += Time.deltaTime;
            }
        }
    }
    
   


}