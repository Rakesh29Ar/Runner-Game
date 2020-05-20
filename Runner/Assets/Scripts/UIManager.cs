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
            Slider.value += 30f*Time.deltaTime;
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
    }




}
