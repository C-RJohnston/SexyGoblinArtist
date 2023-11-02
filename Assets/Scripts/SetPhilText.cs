using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class SetPhilText : MonoBehaviour
{
    private TextMeshPro _text;
    public TextAsset quotes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        _text = GetComponent<TextMeshPro>();
        //var lines = File.ReadAllLines("Assets/PHILosophy.txt");
        var lines = quotes.text.Split('\n');
        var index = Random.Range(0, lines.Length);
        _text.text = lines[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
