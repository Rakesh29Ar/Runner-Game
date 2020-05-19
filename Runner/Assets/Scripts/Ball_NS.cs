using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_NS : MonoBehaviour
{

    private Rigidbody BallRb;

    [SerializeField]
    private float fallmultiplier;
    [SerializeField]
    private float lowjumpmultiplier;

    [SerializeField]
    private float BallForceY;
    private void Start()
    {
        BallRb = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
       /* if(BallRb.velocity.y<0)
        {
            BallRb.
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        BallRb.Sleep();
        BallRb.AddForce(new Vector3(0, BallForceY, 0), ForceMode.Impulse);
    }
}
