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

    public Transform StrokeParent;
    public Transform breadParent;
    private List<Transform> crumbList = new List<Transform>();
    public GameObject breadCrumb;

    public GameManager gameManager;
    private float startScaleX;

    private int trackOrder = 0;

    private float printTimer = 0f;
    public float printThresh;

    public GameObject footPrint;
    public GameObject footParent;
    private int footOrder = 0;

    public Transform from;
    public Transform to;

    private float timeCount = 0.0f;
    private Animator animator;


    void Start()
    {
       
        _canvasObject = GameObject.FindWithTag("Canvas");

        var rect = _canvasObject.GetComponent<Renderer>();
        _validFlySpace = rect.bounds;

        _target = GetRandomPointInBounds(_validFlySpace);

        startScaleX = transform.localScale.x;
        //footParent.transform.SetParent(StrokeParent);
        transform.position = new Vector3(transform.position.x, transform.position.y, -(float)GameManager.Instance.renderOrder / 100);
        animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        Vector3 instPos = StrokeParent.transform.position;
        var footParentInst = Instantiate(footParent, instPos, Quaternion.identity);
        footParentInst.transform.SetParent(StrokeParent);
        foreach (Transform child in footParentInst.transform)
        {
            child.position = new Vector3(child.position.x, child.position.y, -(float)GameManager.Instance.renderOrder / 100);
        }

        foreach(Transform print in footParent.transform)
        {
            Destroy(print.gameObject);
        }
    }


    void Update()
    {

        //check if any breadcrumbs exist and move accordingly
        if(breadParent.transform.childCount == 0)
        {
            _timer += Time.deltaTime;

            animator.speed = 1f;
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
            //_target = crumbList[trackOrder].position;
            
            _target = breadParent.GetChild(0).transform.position;
            transform.position = Vector3.MoveTowards(transform.position, _target, speed * Time.deltaTime * 2f);
            animator.speed = 2f;
        }

        //check input for mouseclick and if its in canvas instantiate breadcrumb, set its parent to breadParent
        var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) & canvasCollider.bounds.IntersectRay(mouseRay))
        {
            Vector3 crumbPos = m_camera.ScreenToWorldPoint(Input.mousePosition);
            crumbPos.z = -gameManager.renderOrder / 100;
            var newCrumb = Instantiate(breadCrumb, crumbPos, Quaternion.identity);
            newCrumb.transform.SetParent(breadParent);
            crumbList.Add(newCrumb.transform);
        }

        //look the right way when walking
        if (transform.position.x < _target.x)
        {
            LookOtherWay(true);
        }
        else if (transform.position.x > _target.x)
        {
            LookOtherWay(false);
        }

        // timer for adding footprints
        printTimer += Time.deltaTime;
        if (printTimer > printThresh)
        {
            FootPrint();
            printTimer = 0f;
        }

        //rotate duck between two values for walking anim
        transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, timeCount);
        timeCount = timeCount + Time.deltaTime;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BreadCrumb"))
        {
            Destroy(collision.gameObject);
            trackOrder++;
            
        }
    }

    private static Vector2 GetRandomPointInBounds(Bounds bounds)
    {
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );
    }



    private void FootPrint()
    {
        if (footOrder % 2 == 0)
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y-0.6f, -(float)GameManager.Instance.renderOrder / 100);
            var newPrint = Instantiate(footPrint, newPos, Quaternion.identity);
            newPrint.transform.SetParent(footParent.transform);
            footOrder++;
            if (transform.position.x < _target.x)
            {
                newPrint.transform.localScale = new Vector3(-newPrint.transform.localScale.x, newPrint.transform.localScale.y, newPrint.transform.localScale.z);
            }
        }
        else
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y-0.4f, -(float)GameManager.Instance.renderOrder / 100);
            var newPrint = Instantiate(footPrint, newPos, Quaternion.identity);
            newPrint.transform.SetParent(footParent.transform);
            footOrder++;
            if (transform.position.x < _target.x)
            {
                newPrint.transform.localScale = new Vector3(-newPrint.transform.localScale.x, newPrint.transform.localScale.y, newPrint.transform.localScale.z);
            }
        }
    }
}