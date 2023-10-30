using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlySwatterScript : MonoBehaviour
{

    [SerializeField] private GameObject flySpawner;


    private void OnEnable()
    {
        flySpawner.SetActive(true);
        
    }

    private void OnDisable()
    {
        if (flySpawner) flySpawner.SetActive(false);
        

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
