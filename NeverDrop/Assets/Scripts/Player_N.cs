using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_N : MonoBehaviour
{
    [SerializeField]
    private float Touchspeed;

    public bool PowerActivated;

    [SerializeField]
    private ParticleSystem splatterparticle;

    [SerializeField]
    private Ball_NS ballref;

    
    public int DiamondCollected;

    public int TotalDiamond;

    public GameObject PlayerBreakPS;

    

    public bool infevermode = false;

    public bool CFL_1 = false;
    public bool CFL_2 = false;

    [SerializeField]
    private float totalpower;

    [SerializeField]
    private float Powerupval;

    [SerializeField]
    private float powerdownvalue;

    [SerializeField]
    private GameObject feversliderGO;

    [SerializeField]
    private Text Diamondtext;

    
    
    [SerializeField]
    private Pathfollow PFref;

    [SerializeField]
    private Slider PowerSliderC;

    [SerializeField]
    private GameObject PowerSliderGO;

    [SerializeField]
    private Camera_S camS_ref;

    [SerializeField]
    private float slowdownfactor;

    [SerializeField]
    private float slowdownlength;

   
    public int Rewardstore;

    







    void Start()
    {
        TotalDiamond = PlayerPrefs.GetInt("totaldiamond", 0);
    }

    // Update is called once per frame
    void Update()
    {

        

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                if(!infevermode)        //(!infevermode&&!CFL_1)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x + touch.deltaPosition.x * Touchspeed , transform.localPosition.y, transform.localPosition.z);
                }
                
            }

            if(touch.phase==TouchPhase.Ended&&CFL_1&&!CFL_2)
            {
                //  Powerup
                
                totalpower = totalpower + Powerupval;
                if(totalpower>120)
                {
                    totalpower = 120;
                }
                PowerSliderC.value = totalpower;

            }

            

        }
        
        
        
        if(transform.localPosition.x>1.75f)
        {
            transform.localPosition = new Vector3(1.75f, transform.localPosition.y, transform.localPosition.z);
        }

        else if(transform.localPosition.x<-1.75f)
        {
            transform.localPosition = new Vector3(-1.75f, transform.localPosition.y, transform.localPosition.z);
        }



        if(CFL_1&&!CFL_2)
        {
            
            Vector3 desiredpos = ballref.transform.position;
            desiredpos.y = transform.position.y;
            desiredpos.z = transform.position.z;
            Vector3 smoothedpos = Vector3.Lerp(transform.position, desiredpos, 0.6f);
            transform.position = smoothedpos;
            //do smooth movement like in fevermode
            //transform.position = new Vector3(ballref.transform.position.x, transform.position.y, transform.position.z);
        }
       /* if(CFL_2)
        {

            Time.timeScale = (1f / slowdownlength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale,0f, 1f);

        }*/
        

    }


    public void DiamondAdd(int diamondamt)
    {
        DiamondCollected =DiamondCollected+ diamondamt;
        TotalDiamond = TotalDiamond + diamondamt;
        UIManager.Instance.TotalDiamondamt(TotalDiamond);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Diamonds"))
        {
            Collectible_S collectiblecompref = other.GetComponent<Collectible_S>();
            int Diamondamt = collectiblecompref.DiamondVal;
            DiamondAdd(Diamondamt);
            Instantiate(collectiblecompref.CuboidEffectprefab, transform.position, Quaternion.identity);
            
            Destroy(other.gameObject);
        }


        else if(other.gameObject.CompareTag("Finishline_1"))
        {
            CFL_1 = true;
            ballref.CFL_1 = true;
            PFref.speed = 20;
            PowerSliderGO.SetActive(true);
            feversliderGO.SetActive(false);
            
            StartCoroutine("PowerDecreaser");
            

        }



        else if(other.gameObject.CompareTag("Finishline_2"))
        {
            CFL_2 = true;
            camS_ref.enabled = true;

           // Doslowmotion();
            
            

           /* Cam_GO.transform.SetParent(ballref.transform);
            Cam_GO.transform.localPosition = new Vector3(0, 5.24f, -32.2f);*/
            

        }

        else if(other.gameObject.CompareTag("Obstacles"))
        {
            other.gameObject.GetComponent<Obstacle_S>().oncollisonfunction(this.gameObject);
        }
            
        
    }

    IEnumerator PowerDecreaser()
    {
        while(!CFL_2)
        {
            if(totalpower>1)
            {
                totalpower = totalpower - powerdownvalue * Time.deltaTime;
                PowerSliderC.value = totalpower;
                yield return null;
            }
            yield return null;
        }

        ballref.Ballimpulse(totalpower);
       
    }

   /* void Doslowmotion()
    {
        Time.timeScale = slowdownfactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }*/

    public void RewardX(int rewardx)
    {
        
        // TotalDiamond = 0;
        TotalDiamond = DiamondCollected * rewardx;
        PlayerPrefs.SetInt("totaldiamond", TotalDiamond);
        Diamondtext.text = TotalDiamond.ToString();
        Rewardstore = rewardx;

    }





}
