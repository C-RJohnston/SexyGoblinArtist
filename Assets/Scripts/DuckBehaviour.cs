using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckBehaviour : MonoBehaviour
{
    public Camera m_camera;
    [SerializeField] private float directionChangeTime;
    [SerializeField] private float speed;

    private float _timer;
    [SerializeField] private float threshold;

    private GameObject _canvasObject;
    public Collider2D canvasCollider;


    private Bounds _validFlySpace;
    private Vector3 _target;


    public Transform breadParent;
    private List<Transform> crumbList;
    public GameObject breadCrumb;

    public GameManager gameManager;
    private float startScaleX;

    void Start()
    {
       
        _canvasObject = GameObject.FindWithTag("Canvas");

        var rect = _canvasObject.GetComponent<Renderer>();
        _validFlySpace = rect.bounds;

        _target = GetRandomPointInBounds(_validFlySpace);

        startScaleX = transform.localScale.x;
    }

    void Update()
    {

        if(breadParent.transform.childCount == 0)
        {
            _timer += Time.deltaTime;

            // move towards the set target
            var step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _target, step);

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
        else
        {
            //add all breadcrumbs to the list and move towards the first one
            foreach(Transform crumb in breadParent)
            {
                crumbList.Add(crumb);
            }
            transform.position = Vector2.MoveTowards(transform.position, crumbList[0].position, 0.1f * Time.deltaTime);
        }

        //check input for mouseclick and if its in canvas instantiate breadcrumb, set its parent to breadParent
        var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) )
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = gameManager.renderOrder / 100;
            Vector3 crumbPos = m_camera.ScreenToWorldPoint(mousePos);
            breadCrumb = Instantiate(breadCrumb, crumbPos, Quaternion.identity);
            breadCrumb.transform.SetParent(breadParent);
        }

        
        if (transform.position.x < _target.x)
        {
            LookOtherWay(true);
        }
        else if (transform.position.x > _target.x)
        {
            LookOtherWay(false);
        }
        

    }

    private void LookOtherWay(bool lookRight)
    {
        if (lookRight)
        {
            transform.localScale = new Vector3(-startScaleX, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(startScaleX, transform.localScale.y, transform.localScale.z);
        }
    }


    private static Vector2 GetRandomPointInBounds(Bounds bounds)
    {
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );
    }
}