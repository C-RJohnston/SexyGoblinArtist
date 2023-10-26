using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrays : MonoBehaviour
{

    public GameObject[] squares;

    // Start is called before the first frame update
    void Start()
    {
        squares = GameObject.FindGameObjectsWithTag("Square");

        for (int i = 0; i < squares.Length; i++)
        {
            Debug.Log("Square Number "+i+" is named "+squares[i].name);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
