using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_S : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float smoothspeed;
    [SerializeField]
    private Vector3 offset;



    void Update()
    {
        Vector3 desiredpos = target.position + offset;
        Vector3 smoothedpos = Vector3.Lerp(transform.position, desiredpos, smoothspeed*Time.deltaTime);
        transform.position = smoothedpos;

       // transform.LookAt(target);
    }
    
}
