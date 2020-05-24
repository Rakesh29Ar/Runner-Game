using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_N : MonoBehaviour
{
    [SerializeField]
    private float Touchspeed;

    public bool PowerActivated;

    [SerializeField]
    private ParticleSystem splatterparticle;

    public bool infevermode = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                if(!infevermode)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x + touch.deltaPosition.x * Touchspeed * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
                }
                
            }

        }
    }

    


}
