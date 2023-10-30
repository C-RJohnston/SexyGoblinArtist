using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int renderOrder = 0;
    public GameObject strokeParent;
    public List<GameObject> BrushList;
    private int _brushOrder = 0;
    [HideInInspector] public GameObject currentBrush { get; set; }

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentBrush = BrushList[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            DestroyLastObject();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeBrush();
        }
    }


    public void DestroyLastObject()
    {
        var childrenList = new List<Transform>();
        foreach (Transform child in strokeParent.transform)
        {
            childrenList.Add(child);
        }

        Destroy(childrenList[childrenList.Count - 1].gameObject);
    }
    
    
    private void ChangeBrush()
    {
        _brushOrder++;
        if (_brushOrder < BrushList.Count)
        {
            currentBrush = BrushList[_brushOrder];
        }
        else
        {
            _brushOrder = 0;
            currentBrush = BrushList[_brushOrder];
        }
    }
}
