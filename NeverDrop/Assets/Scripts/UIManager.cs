using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Slider Slider;

    [SerializeField]
    private float maxvalue;

    [SerializeField]
    private Color LVcolor;

    [SerializeField]
    private Text DiamondUI;

    [SerializeField]
    private GameObject HandGO;

    [SerializeField]
    private GameObject PlayUIGO;

    [SerializeField]
    private GameObject RetryGO;





    [SerializeField]
    private Pathfollow pathfollow_c;

    private int leveltoload;

    private int nextleveltoload;

    [SerializeField]
    private GameObject NextlevelUI;

    [SerializeField]
    private GameObject ballGO;

    private bool NLuiShown = false;

    private Scene Level;

    [SerializeField]
    private Text CLuiT;
    [SerializeField]
    private Text NLuiT;

    private int clt;

    [SerializeField]
    private GameObject taptoplay;

    [SerializeField]
    private Player_N playerNref;








    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("the ui manager is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;

        
    }

    void Start()
    {

        Slider.maxValue = maxvalue;
        Slider.value = 0;
        DiamondUI.text = PlayerPrefs.GetInt("totaldiamond", 0).ToString();
       
        clt= PlayerPrefs.GetInt("CLT_p", 1);
        CLuiT.text = clt.ToString();
        int nl = clt + 1;
        NLuiT.text = nl.ToString();
        /* leveltoload = PlayerPrefs.GetInt("currentlevel", 0);
         SceneManager.LoadScene(leveltoload);*/


        TinySauce.OnGameStarted(levelNumber: clt.ToString());

    }

    
    

    public void UBallmeter(float health)
    {
        //Slider.value = health;
        if(health>1)
        {
            StopCoroutine("SliderZero");
            StartCoroutine(SliderSmooth(health));
        }
        else
        {
            StopCoroutine("SliderSmooth");
            StartCoroutine(SliderZero());
        }
    }

    IEnumerator SliderSmooth(float currentvalue)
    {
        while(Slider.value<currentvalue)
        {
            Slider.value += 60f*Time.deltaTime;
            //if slider value <25 change slider color to light green
            //if slider value>25 but less that 75 dark green
            //if slier value > 75 change color to red
          



            yield return null;
        }
    }

    IEnumerator SliderZero()
    {
        while(Slider.value>1)
        {
            Slider.value -= 100 * Time.deltaTime;
            yield return null;
        }

        //change slider color to default color
    }

    public void TotalDiamondamt(int totaldiamond)
    {
        DiamondUI.text = totaldiamond.ToString();
    }



    public void Play()
    {
        ballGO.SetActive(true);
        pathfollow_c.enabled = true;
        HandGO.SetActive(false);
        PlayUIGO.SetActive(false);
        taptoplay.SetActive(false);
    }

    public void RestartLevel()
    {

        int dCollected = playerNref.DiamondCollected;
        TinySauce.OnGameFinished(levelNumber: clt.ToString(), false, dCollected);

        Level = SceneManager.GetActiveScene();
        SceneManager.LoadScene(Level.name);
        


    }

    public void showretry()
    {
        RetryGO.SetActive(true);
    }

    public void NextLevel()
    {
        clt += 1;
        PlayerPrefs.SetInt("CLT_p", clt);
        
         nextleveltoload = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextleveltoload<8)
        {
            PlayerPrefs.SetInt("currentlevel", nextleveltoload);
            SceneManager.LoadScene(nextleveltoload);
            
        }
        else
        {
            nextleveltoload = 5;
            PlayerPrefs.SetInt("currentlevel", nextleveltoload);
            SceneManager.LoadScene(nextleveltoload);
            

        }



    }

    public void ShowNextui()
    {

        if(!NLuiShown)
        {
            NextlevelUI.SetActive(true);
            int dCollected = playerNref.DiamondCollected * playerNref.Rewardstore;


            TinySauce.OnGameFinished(levelNumber: clt.ToString(), true, dCollected);


            NLuiShown = true;

           // PlayerPrefs.SetInt("")

        }
        
    }




}
