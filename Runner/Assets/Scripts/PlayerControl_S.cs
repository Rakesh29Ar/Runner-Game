using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_S : MonoBehaviour
{

    public Transform ball;

    private Touch touch;

    [SerializeField]
    private float Touchspeed;


    // Start is called before the first frame update
    void Start()
    {
       //Touchspeed = 1;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y, ball.position.z);

        if(Input.touchCount>0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase==TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * Touchspeed*Time.deltaTime, transform.position.y, transform.position.z );
            }

        }






    }
}
