using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private Collider otherobj;
    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {
        otherobj = other;
        PoolManager.Instance.Setptpos();
        Invoke("Hide", 1);
    }


    void Hide(Collider other)
    {
        otherobj.gameObject.SetActive(false);
    }

}
