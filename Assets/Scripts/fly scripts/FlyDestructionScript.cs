using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyDestructionScript : MonoBehaviour
{
    [SerializeField] private GameObject splat;
    private GameObject _brushParent;
    
    // Start is called before the first frame update
    void Start()
    {
        _brushParent = GameObject.FindWithTag("StrokeManager");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            /*
             * splat animation
             */
            
            /*
             * draw splat
             */
            Transform t = transform;
            var splatIn = Instantiate(splat, t.position, t.rotation, _brushParent.transform);
            GameManager.Instance.renderOrder++;
            //splatIn.GetComponent<SpriteRenderer>().sortingOrder = GameManager.Instance.renderOrder;
            var p = splatIn.transform.position;
            splatIn.transform.position = new Vector3(
                p.x,
                p.y,
                -(float)GameManager.Instance.renderOrder / 100);

            /*
             * destroy fly
             */
            Destroy(this.gameObject);
        }
    }
}
