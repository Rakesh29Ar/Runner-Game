using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation;


public class Ball_NS : MonoBehaviour
{
    
    public Rigidbody BallRb;

    [SerializeField]
    private Transform playergo;

    [SerializeField]
    private GameObject PMgo;

    [SerializeField]
    private GameObject PMref;

    [SerializeField]
    private ParticleSystem BallPS;

    [SerializeField]
    private ParticleSystem FevermodePS;

       

    [SerializeField]
    private Slider BallMeterSlider;

    [SerializeField]
    private bool FeverMode=false;

    [SerializeField]
    private Transform Playertransform;

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private float BallForceY;

    [SerializeField]
    private float Perfect=0;

    [SerializeField]
    private ParticleSystem SplatterParticles;

    [SerializeField]
    private float FinalYforce;

    [SerializeField]
    private Color fevercolor;

    private Color Normalfogcolor;

    private Vector3 prevpos;

    private Transform balltransform;

    public bool CFL_1 = false;
    public bool CFL_2 = false;
    private void Start()
    {
        BallRb = GetComponent<Rigidbody>();
        balltransform = GetComponent<Transform>();
        
    }

    private void Update()
    {
        if(transform.position.x>1.5f)
        {
             balltransform.position = new Vector3(1.5f, transform.position.y, transform.position.z);
            
        }
        else if(transform.position.x<-1.5f)
        {
            balltransform.position = new Vector3(-1.5f, transform.position.y, transform.position.z);
        }
    }





    private void OnCollisionEnter(Collision collision)
    {
     /*   BallRb.Sleep();                                     //debug position
        BallRb.AddForce(new Vector3(0, BallForceY, 0), ForceMode.Impulse);*/
       /* Vector3 currentpos = transform.position;
        Vector3 diff = currentpos - prevpos;
        prevpos = currentpos;
        Debug.Log(diff.z);*/
        
        
        





        if (collision.gameObject.CompareTag("Player"))
        {


            BallRb.Sleep();
            if (!CFL_1)
            {



                BallRb.AddForce(new Vector3(Random.Range(-7, 7), BallForceY, 0), ForceMode.Impulse);      //Random.Range(-10,10)
                Vector3 Perfectdiff = Playertransform.position - transform.position;
                float PDabs = Mathf.Abs(Perfectdiff.x);



                // SplatterParticles.transform.position = collision.transform.position;
                //  SplatterParticles.Emit(4);


                if (Perfect == 102&&!CFL_1)
                {
                    Perfect = 102;
                    // Player.GetComponent<Player_N>().PowerActivated = true;
                    FeverMode = true;
                    fastmotion();
                    FevermodePS.Play();
                    Player.GetComponent<Player_N>().infevermode = true;
                    StartCoroutine("FeverDecrease");
                    //coroutine smooth color

                    Normalfogcolor = RenderSettings.fogColor;
                    StartCoroutine(smoothcolorchange(fevercolor));

                    
                   // RenderSettings.fogColor = fevercolor;


                }

                if (PDabs < 0.1 && !FeverMode) //Perfect point distance value from centre, change the value according to size of object
                {
                    if (Perfect < 100)
                    {
                        Perfect = Perfect + 34;

                        UIManager.Instance.UBallmeter(Perfect);

                    }

                }
                else if (!FeverMode)
                {
                    Perfect = 0;

                    //after crossing finish line make it invisibe
                    UIManager.Instance.UBallmeter(Perfect);
                }
            }
            
        }
        else if(collision.gameObject.CompareTag("Environment"))
        {
            
            BallPS.transform.position = transform.position;
            if(playergo!=null)
            {
                playergo.transform.parent.DetachChildren();
            }
           // playergo.transform.parent.DetachChildren();

            Destroy(this.gameObject);
            BallPS.Play();
            UIManager.Instance.showretry();
            
            
           // playergo.parent = null;
           // Destroy(PMgo);


            //do camera effects here

        }



    }


    IEnumerator  FeverDecrease()
    {
        while(Perfect>1&&!CFL_1)
        {
            Perfect =Perfect- 10f * Time.deltaTime;
            BallMeterSlider.value = Perfect;

            Vector3 desiredpos = transform.position;
            desiredpos.y = Playertransform.position.y;
            desiredpos.z = Playertransform.position.z;
            Vector3 smoothedpos = Vector3.Lerp(Playertransform.position, desiredpos, 0.6f);
            Playertransform.position = smoothedpos;


            yield return null;
        }
        FeverMode = false;
        undofastmotion();
        Perfect = 0;
        FevermodePS.Stop();
        Player.GetComponent<Player_N>().infevermode = false;
        // RenderSettings.fogColor = Normalfogcolor;
        StartCoroutine(smoothcolorchange(Normalfogcolor));
    }


    IEnumerator smoothcolorchange(Color desiredcolor)
    {
        Color lerpedcolor= new Color(1, 1, 1, 1); 
        while(desiredcolor!=lerpedcolor)
        {
            Color currentcolor = RenderSettings.fogColor;
            lerpedcolor = Color.Lerp(currentcolor, desiredcolor, 0.1f);
            RenderSettings.fogColor = lerpedcolor;
            yield return null;
        }
    }

    void fastmotion()
    {
        Time.timeScale = 2f;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
    void undofastmotion()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    public void Ballimpulse(float power)
    {
       if(power>10)
        {
            BallRb.AddForce(new Vector3(0, FinalYforce, power), ForceMode.Impulse);
        }
       else
        {
            power = 15;
            BallRb.AddForce(new Vector3(0, FinalYforce, power), ForceMode.Impulse);
        }
    }
        

}
