using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondRandX : MonoBehaviour
{

    

    [SerializeField]
    private float minX;

    [SerializeField]
    private float maxX;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(Random.Range(minX, maxX), transform.localPosition.y, transform.localPosition.z);
    }

    // Update is called once per frame
    
}
