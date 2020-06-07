using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyPS : MonoBehaviour
{
    [SerializeField]
    private float Timetodestroy;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("autodestroy",Timetodestroy);
    }

    void autodestroy()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    
}
