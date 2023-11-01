using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBrush : MonoBehaviour
{
    public Camera m_camera;
    public Transform strokeParent;

    public GameObject[] flowers;

    private float timer;
    public float thresh = .5f;

    public Collider2D canvasCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0) & timer > thresh)
        {
            Vector3 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = -(float)GameManager.Instance.renderOrder / 100;
            var newFlower = Instantiate(flowers[Random.Range(0, flowers.Length)],mousePos,Quaternion.identity);
            newFlower.transform.SetParent(transform);
            
            timer = 0;
        }
    }

    private void OnDisable()
    {
        
    }
}
