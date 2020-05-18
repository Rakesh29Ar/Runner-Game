using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_S : MonoBehaviour
{


    private Rigidbody rb;
    [SerializeField]
    private Vector3 ballforce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        rb.Sleep();
        rb.AddForce(ballforce, ForceMode.Impulse);


    }

}
