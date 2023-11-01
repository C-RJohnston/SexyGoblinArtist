using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovementAI : MonoBehaviour
{
    private PaddleMovement _paddleMovement;
    public float speed;
    public float threshold;
    private void Awake()
    {
        _paddleMovement = GetComponent<PaddleMovement>();
    }
    
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AboveIsh(ball))
        {
            _paddleMovement.MoveUp(speed * Time.deltaTime);
        }
        else if (BelowIsh(ball))
        {
            _paddleMovement.MoveUp(speed * Time.deltaTime * -1f);
        }
    }

    bool AboveIsh(GameObject target)
    {
        var dist = target.transform.position.y - transform.position.y;
        if (dist > threshold)
        {
            return true;
        }
        else return false;
    }
    bool BelowIsh(GameObject target)
    {
        var dist = target.transform.position.y - transform.position.y;
        if (dist < -threshold)
        {
            return true;
        }
        else return false;
    }
}
