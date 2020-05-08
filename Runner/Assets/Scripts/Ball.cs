using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float BallForce;

    [SerializeField]
    private float BallforceX;

    [SerializeField]
    private Transform Player;

    [SerializeField]
    private GameObject trackobj;

    private Rigidbody BallRb;

    private float[] LSRforce = { -0.5f,0, 0.5f };

    private bool isstraight=true;
    private bool isleft=false;
    private bool isright=false;

    float prevZ=0;
    int i = 0;
    bool executed = false;
    // Start is called before the first frame update
    void Start()
    {
        BallRb = GetComponent<Rigidbody>();
        executed = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Player.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        BallRb.Sleep();
        Debug.Log(transform.position.z);

          float currentZ = transform.position.z;
          float difference = currentZ - prevZ;
          prevZ = currentZ;
          Debug.Log(difference);
          Debug.Log(difference/2);

         /* if (transform.position.x>0.8)
          {

              BallRb.AddForce(new Vector3(-0.5f, BallForce, 0), ForceMode.Impulse);

          }
          else if(transform.position.x<-0.8)
          {
              BallRb.AddForce(new Vector3(0.5f, BallForce, 0), ForceMode.Impulse);

          }
          else
          {
              BallRb.AddForce(new Vector3(LSRforce[Random.Range(0,3)], BallForce, 0), ForceMode.Impulse);
          }*/

        BallRb.AddForce(new Vector3(0, BallForce, 0), ForceMode.Impulse); //testing force for different GM speed
        
       
        
        
        
       
        
    }
}
