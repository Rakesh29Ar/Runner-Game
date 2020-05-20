using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blower : MonoBehaviour
{
    [SerializeField]
    private float BForceRight;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(BForceRight, 0, 0);
    }
}
