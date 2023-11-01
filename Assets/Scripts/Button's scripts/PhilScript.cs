using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhilScript : MonoBehaviour
{
    public GameObject phil;
    private Vector3 startPos;
    public Vector3 targetPos;
    public float speed;
    public Animator animator;
   
    // Start is called before the first frame update
    void Start()
    {
        //startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      //transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
    }



    public void whenButtonClicked()
    {

        // transform.position = targetPos;
        //transform.position = new Vector3(-7, -5, 0);
        animator.Play("PhilAnimation");

    }

   


}