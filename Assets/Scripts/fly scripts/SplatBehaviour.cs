using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// TODO sync colour of splat to chosen brush colour
public class SplatBehaviour : MonoBehaviour
{
    private void OnEnable()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = GameManager.Instance.currentBrush.GetComponent<Renderer>().sharedMaterial.color;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
