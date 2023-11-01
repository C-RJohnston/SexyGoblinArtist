using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class SetColour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = GameManager.Instance.currentBrush.GetComponent<Renderer>().sharedMaterial.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
