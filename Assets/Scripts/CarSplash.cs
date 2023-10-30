using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSplash : MonoBehaviour
{
    public Vector3 endPos;
    public float moveMult;

    public Vector3 endScale;
    public float scaleMult;

    public GameManager gameManager;
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPos, moveMult);
        transform.localScale = Vector3.MoveTowards(transform.localScale, endScale, scaleMult);

    }
}
