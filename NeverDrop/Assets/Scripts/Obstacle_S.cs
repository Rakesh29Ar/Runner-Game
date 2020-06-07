using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_S : MonoBehaviour
{



    [SerializeField]
    private GameObject PS_Prefab;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private float minX;

    [SerializeField]
    private float maxX;






    private void Start()
    {
        offset.x = Random.Range(minX,maxX);
        transform.localPosition = offset;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

            // oncollisonfunction(collision);
            //do camera effect
            GameObject PlayerrefGO = collision.gameObject;
            oncollisonfunction(PlayerrefGO);
        }
    }


    public void oncollisonfunction(GameObject collision)
    {
        if (!collision.GetComponent<Player_N>().infevermode)
        {
            // collision.transform.DetachChildren();
            GameObject parentref = collision.transform.parent.gameObject;
            parentref.transform.DetachChildren();
            Destroy(parentref.gameObject);
            GameObject playerref = collision;
            Instantiate(playerref.GetComponent<Player_N>().PlayerBreakPS, collision.transform.position, Quaternion.identity);


            Destroy(collision.gameObject);
            UIManager.Instance.showretry();



        }
        else
        {
            //do  break effects here
            Destroy(this.gameObject);
            Vector3 pos = collision.transform.position;
            Instantiate(PS_Prefab, pos, Quaternion.identity);

        }

    }



}
