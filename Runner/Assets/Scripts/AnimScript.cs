using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
    [SerializeField]
    private GameObject ParentObj;

    [SerializeField]
    private GameObject playerholderobj;

    [SerializeField]
    private Vector3 RayStartoffset;

    [SerializeField]
    private float RayHeight;

    [SerializeField]
    private GameObject GMobj;

    private bool ismoving = false;

    float prvZ=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AnimEvent()
    {
        RaycastHit hit;
        Ray LandingRay=new Ray(ParentObj.transform.position+RayStartoffset,Vector3.down);
        Debug.DrawRay(ParentObj.transform.position, Vector3.down * RayHeight);
        float currentz = GMobj.transform.position.z;
        
        float differnceZ = currentz - prvZ;
        prvZ = currentz;
        Debug.Log(differnceZ);
        if(Physics.Raycast(LandingRay,out hit,RayHeight))
        {   
        
            if (hit.collider.tag == "ground") 
            {
                //then make game over
            }
          else
            {
                //transform the x position by local between the velues
                Vector3 Targetpos = new Vector3(Random.Range(-2.5f, 2.5f), ParentObj.transform.localPosition.y, 0);  //Random.Range(-2.5f, 2.5f)
                StartCoroutine(Movetoposition(ParentObj.transform.localPosition, Targetpos, 1.25f));

            }
        }
        else
        {

            //game over

        }

    }

    IEnumerator Movetoposition(Vector3 frompos,Vector3 endpos,float duration)
    {
        if(ismoving)
        {
            yield break;
        }
        ismoving = false;

        float counter = 0;





        Vector3 startpos = frompos;
        
        while(counter<duration)
        {
            counter += Time.deltaTime;
            ParentObj.transform.localPosition = Vector3.Lerp(startpos, endpos, counter / duration);
            yield return null;

        }
        ismoving = false;
    }

}
