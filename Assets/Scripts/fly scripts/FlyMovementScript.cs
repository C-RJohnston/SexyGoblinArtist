using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

// TODO rotate fly towards target
public class FlyMovementScript : MonoBehaviour
{
    [SerializeField] private float directionChangeTime;
    [SerializeField] private float speed;

    private float _timer;
    [SerializeField] private float threshold;

    [CanBeNull] private GameObject _canvasObject;

    private Bounds _validFlySpace;

    private Vector3 _target;
    // Start is called before the first frame update
    void Start()
    {
        /*
         * Define the area in which the fly will look for new places to move to
         */
        
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
        // set initial target
        _target = GetRandomPointInBounds(_validFlySpace);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        
        // move towards the set target
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _target, step);
        
        
        // change direction after a set amount of time
        if (_timer >= directionChangeTime)
        {
            
            _target = GetRandomPointInBounds(_validFlySpace);
            _timer -= directionChangeTime;
        }
        // change direction if reached target
        var dist = Vector3.Distance(transform.position, _target);
        if (dist <= threshold)
        {
            
            _target = GetRandomPointInBounds(_validFlySpace);
            _timer -= directionChangeTime;
        }

    }

    private static Vector3 GetRandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
