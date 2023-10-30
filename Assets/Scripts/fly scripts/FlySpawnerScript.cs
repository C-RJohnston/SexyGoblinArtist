using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlySpawnerScript : MonoBehaviour
{

    public GameObject fly;
    
    public int initialSpawns;

    // do not make zero
    public int spawnInterval;
    
    private float _timer;

    [CanBeNull] private GameObject _canvasObject;
    private Bounds _validFlySpace;

    // Start is called before the first frame update
    void Start()
    {
        // check to see if the scene contains a canvas
        _canvasObject = GameObject.FindWithTag("Canvas");
        
        if (_canvasObject)
        {
            var rect = _canvasObject.GetComponent<Renderer>();
            _validFlySpace = rect.bounds;
        }
        else
        {
            // if no valid canvas, use whole screen
            float verticalHeightSeen = Camera.main.orthographicSize * 2.0f;
            float verticalWidthSeen = verticalHeightSeen * Camera.main.aspect;
            _validFlySpace = new Bounds(Vector3.zero, new Vector3(
                verticalWidthSeen, verticalHeightSeen, 0));
        }
        
        for (int i = 0; i < initialSpawns; i++)
        {
            Instantiate(fly, GetRandomPointInBounds(_validFlySpace),
                quaternion.identity, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= spawnInterval)
        {
            // TODO change to be random point just outside the screen
            Instantiate(fly, GetRandomPointInBounds(_validFlySpace),
                quaternion.identity, transform);
            _timer -= spawnInterval;
        }
    }
    
    
    private static Vector3 GetRandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            -9.9f
        );
    }


}
