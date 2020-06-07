using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_S : MonoBehaviour
{

    [SerializeField]
    public int DiamondVal;

    [SerializeField]
    public GameObject CuboidEffectprefab;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent.localPosition = new Vector3(Random.Range(-1.5f, 1.5f), transform.parent.localPosition.y, transform.parent.localPosition.z);
       // transform.localPosition = new Vector3(Random.Range(-1.5f,1.5f), transform.localPosition.y, transform.localPosition.z);
    }

    
}
