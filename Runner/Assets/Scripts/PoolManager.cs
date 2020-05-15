using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Platformprefab;

    [SerializeField]
    private GameObject Obstacleprefab;

    [SerializeField]
    private List<GameObject> Platformpool;

    [SerializeField]
    private List<GameObject> Obstaclepool;

    [SerializeField]
    private GameObject PlatformContainer;

    [SerializeField]
    private GameObject ObstacleContainer;


    Vector3 NxtPtPos = new Vector3(0, 0, 0);

    Vector3 PrvObsPos;
    [SerializeField]
    float[] NxtLandPosZ;
    [SerializeField]
    float ObsDiff;
    float ObsposZ;
    private bool firstinit=true;


    private static PoolManager _instance;
    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("the pool manager is null");
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
        Platformpool = GeneratePlatform(30);

        SetplatformPosInit();

        Obstaclepool = GenerateObstacle(30);


    }


    //Generte platform
    List<GameObject> GeneratePlatform(int amount)
    {
      for(int i=0;i<amount;i++)
        {
            GameObject PlatformObj = Instantiate(Platformprefab);
            PlatformObj.transform.parent = PlatformContainer.transform;
            PlatformObj.SetActive(false);
            Platformpool.Add(PlatformObj);
        }
        return Platformpool;
       
    }

    //obstacle
    List<GameObject>GenerateObstacle(int amt)
    {
        for(int i=0;i<amt;i++)
        {
            GameObject ObstacleObj = Instantiate(Obstacleprefab);
            ObstacleObj.transform.parent = ObstacleContainer.transform;
            ObstacleObj.SetActive(false);
            Obstaclepool.Add(ObstacleObj);
        }
        return Obstaclepool;
        
    }

    //platform
    void SetplatformPosInit()
    {
        
      

        for(int i=0;i<10;i++)
        {
            Platformpool[i].SetActive(true);
            Platformpool[i].transform.position = NxtPtPos;
            NxtPtPos.z += 10;
        }
    }

  /*  public void SetObsPosInit(Vector3 Initpos)
    {
        for(int i=0;i<10;i++)
        {
            Obstaclepool[i].SetActive(true);
            Obstaclepool[i].transform.position = NxtObsPos;
            NxtObsPos.z += ObsDiff;
        }

    }*/



        //platform
    public GameObject RequestPlatform()
    {
        foreach(var platform in Platformpool)
        {
            if(platform.activeInHierarchy==false)
            {
                platform.SetActive(true);
                return platform;
            }

        }
        GameObject newPlatformObj = Instantiate(Platformprefab);
        newPlatformObj.transform.parent = PlatformContainer.transform;
        newPlatformObj.SetActive(true);
        Platformpool.Add(newPlatformObj);
        return newPlatformObj;

    }

    //obstacle
    public GameObject RequestObstacle()
    {

        foreach(var obstacle in Obstaclepool)
        {
            if(obstacle.activeInHierarchy==false)
            {
                obstacle.SetActive(true);
                return obstacle;
            }

        }
        GameObject newObstacle = Instantiate(Obstacleprefab);
        newObstacle.transform.parent = ObstacleContainer.transform;
        newObstacle.SetActive(true);
        Obstaclepool.Add(newObstacle);
        return newObstacle;

    }


    //platform

    public void Setptpos()
    {
        GameObject Platform = PoolManager.Instance.RequestPlatform();
        Platform.transform.position = NxtPtPos;
        NxtPtPos.z += 10;

    }


    //obstacle

    public void SetObstaclespos(Vector3 ballpos)
    {

        GameObject obstacle = PoolManager.Instance.RequestObstacle();

        obstacle.transform.position = new Vector3(0,0,ballpos.z) + new Vector3(0, 0, ObsDiff * 3-4);
    }





}
