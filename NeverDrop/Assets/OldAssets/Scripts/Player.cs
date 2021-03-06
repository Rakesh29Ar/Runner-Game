﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float Touchspeed;

    [SerializeField]
    private GameObject trackobj;

    // Start is called before the first frame update
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
                transform.localPosition = new Vector3(transform.localPosition.x + touch.deltaPosition.x * Touchspeed * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
            }

        }
        
    }
}
