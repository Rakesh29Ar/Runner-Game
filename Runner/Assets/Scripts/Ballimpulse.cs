using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballimpulse : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;

    [SerializeField]
    private float ballspeedz;

    [SerializeField]
    private Vector3 ballforce=new Vector3(0,3,3);
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballspeedz = rb.velocity.z;
    }

    private void Update()
    {
        ballspeedz = rb.velocity.z;
    }


    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
            rb.Sleep();
            ballforce = new Vector3(0,3,3);
            rb.AddForce(ballforce, ForceMode.Impulse);
        
    }


}
