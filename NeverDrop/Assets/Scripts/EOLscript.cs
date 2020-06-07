using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EOLscript : MonoBehaviour
{

    [SerializeField]
    private GameObject PlayerGO;

    [SerializeField]
    private Player_N PlayerN_ref;

    [SerializeField]
    private int rewardX;

    [SerializeField]
    private GameObject eoleffect;

    private int index=0;

    private GameObject ballgoref;

    



    // Start is called before the first frame update
    

    // Update is called once per frame
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Ball"))
        {
            if(index==0)
            {
                Instantiate(eoleffect, collision.transform.position, Quaternion.identity);
                PlayerN_ref.RewardX(rewardX);
                index++;
                ballgoref = collision.gameObject;

                Invoke("BallSleep", 4);
            }
            
            

           // PlayerN_ref.DiamondCollected = PlayerN_ref.DiamondCollected * rewardX;
           // PlayerN_ref.TotalDiamond=tot
        }


    }


    void BallSleep()
    {
        ballgoref.GetComponent<Ball_NS>().BallRb.Sleep();
        UIManager.Instance.ShowNextui();
    }








}
