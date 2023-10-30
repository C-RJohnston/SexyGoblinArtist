using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int renderOrder = 0;
    public GameObject strokeParent;

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            DestroyLastObject();
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
}
