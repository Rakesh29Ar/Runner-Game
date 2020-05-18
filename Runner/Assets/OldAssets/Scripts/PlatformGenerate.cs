using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerate : MonoBehaviour
{
    
   private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            PoolManager.Instance.Setptpos();
           // PoolManager.Instance.SetObsPos(new Vector3(0,0,0));
            Invoke("Hide", 1);
        }
        
        
    }


    

    void Hide()
    {

        this.gameObject.SetActive(false);
    }

}
