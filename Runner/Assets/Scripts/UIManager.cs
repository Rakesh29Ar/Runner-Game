using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Slider Slider;

    [SerializeField]
    private float maxvalue;

    [SerializeField]
    private Color LVcolor;

    





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
    }

    // Update is called once per frame
    void Update()
    {
        
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




}
