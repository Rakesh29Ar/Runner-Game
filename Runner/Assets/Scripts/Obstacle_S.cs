using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_S : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(!collision.gameObject.GetComponent<Player_N>().infevermode)
            {
                collision.transform.DetachChildren();

                Destroy(collision.gameObject);
            }
           
           
            //do camera effect
        }
    }




}
