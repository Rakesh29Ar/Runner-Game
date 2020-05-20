using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_NS : MonoBehaviour
{
    
    private Rigidbody BallRb;

    [SerializeField]
    private GameObject ParentObj;

    private bool ismoving = false;

    [SerializeField]
    private float fallmultiplier;
    [SerializeField]
    private float lowjumpmultiplier;

    [SerializeField]
    private float BallForceY;

    [SerializeField]
    private int Perfect=0;
    private void Start()
    {
        BallRb = GetComponent<Rigidbody>();
        
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        BallRb.Sleep();
        BallRb.AddForce(new Vector3(0, BallForceY, 0), ForceMode.Impulse);
        Vector3 Perfectdiff = new Vector3(0, 0, 0) - transform.localPosition;
        float PDabs = Mathf.Abs(Perfectdiff.x);
        if(PDabs<0.05) //Perfect point distance value from centre, change the value according to size of object
        {
            if(Perfect<100)
            {
                Perfect = Perfect + 20;

                UIManager.Instance.UBallmeter(Perfect);
            }
            
        }
        else
        {
            Perfect = 0;

            //after crossing finish line make it invisibe
            UIManager.Instance.UBallmeter(Perfect);
        }
    }

    /*public void Animevent()
    {
        Vector3 Targetpos = new Vector3(Random.Range(-1.3f, 1.3f), ParentObj.transform.localPosition.y, 0);  //Random.Range(-2.5f, 2.5f)
        StartCoroutine(Movetoposition(ParentObj.transform.localPosition, Targetpos, 1f));
    }




    IEnumerator Movetoposition(Vector3 frompos, Vector3 endpos, float duration)
    {
        if (ismoving)
        {
            yield break;
        }
        ismoving = false;

        float counter = 0;





        Vector3 startpos = frompos;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            ParentObj.transform.localPosition = Vector3.Lerp(startpos, endpos, counter / duration);
            yield return null;

        }
        ismoving = false;
    }*/




}
