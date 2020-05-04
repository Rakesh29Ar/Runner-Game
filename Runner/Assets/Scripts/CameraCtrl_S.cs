using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl_S : MonoBehaviour
{

    public Transform target;

    public float smoothspeed = 0.9f;
    public Vector3 offset;

    
    

    
    private void FixedUpdate()
    {
        Vector3 desiredpos = target.position + offset;
        Vector3 smoothedpos = Vector3.Lerp(transform.position, desiredpos, smoothspeed);
       // smoothedpos.x = target.position.x;
        transform.position = smoothedpos;
        
        //transform.LookAt(target);
        


    }
}
