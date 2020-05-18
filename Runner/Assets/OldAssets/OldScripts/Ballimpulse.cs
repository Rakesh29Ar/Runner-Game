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

        //1.predict force based on position
        //2.how can u set end position
        //3.by setting random value in x,default value in y that is 0 or some value based on path y value ,random value in z or some predefined z value forward
        //4.then using current pos and end pos we can determine force needed then add force to ball



        rb.Sleep();
        Vector3 endpos = new Vector3(Random.Range(-1.4f,1.4f), 0,transform.position.z+ 15 );  //Random.Range(7,10)
        Vector3 Ballvelocity = calculatevelocity(endpos, transform.position, 1);
        transform.rotation = Quaternion.identity;
        // rb.velocity = Ballvelocity;
        ballforce = rb.mass * (Ballvelocity / 1);
       // ballforce.y = 3;
       // ballforce = new Vector3(3,3,3);
        rb.AddForce(ballforce, ForceMode.Impulse);
        
    }



   /* void Setendpos()
    {
        Vector3 endpos



    }*/

    Vector3 calculatevelocity(Vector3 target,Vector3 origin,float time)
    {


        Vector3 distance = target - origin;
        Vector3 distancexz = distance;
        distancexz.y = 0f;

        

        float dy = distance.y;
        float dxz = distancexz.magnitude;

        float Vxz = dxz / time;
        float Vy = dy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distancexz.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;



    }


}
