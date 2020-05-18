using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacles;
    [SerializeField]
    private float FirstobsDiff;
    [SerializeField]
    private float ConstobsDiff;
    // Start is called before the first frame update
    [SerializeField]
    private float[] nextlandposZ;
    void Start()
    {
        // ObsSetpos(); 
        //Obsrandpos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ObsSetpos()
    {
        obstacles[0].transform.position = new Vector3(obstacles[0].transform.position.x, obstacles[0].transform.position.y, FirstobsDiff);
        for (int i = 1; i < 15; i++)
        {
            obstacles[i].transform.position = new Vector3(obstacles[i].transform.position.x, obstacles[i].transform.position.y, obstacles[i - 1].transform.position.z + ConstobsDiff);


        }
    }


    //1.get first obstacle position based 
    //2.then get the diff between points of ball landing
    //3.then you can spawn obstacles as many as you want with in that position e.g start pos 0 end pos 10 within this spawn as many obstacles you want, there should be
    //minimum distance between the obstacles
    //

    public void Obsrandpos(Vector3 ballpos)
    {

        int index = 1;
        float firstlandpos=ballpos.z;
       // firstlandpos = 0;
        int currentobsindex = 1;
        float obsposz;


        nextlandposZ[0] = firstlandpos;
        for (int i = 0; i < 15; i++)
        {
            if (i == 0)
            {
                obstacles[0].transform.position = new Vector3(0, 0, nextlandposZ[0] + 3);
            }
            else
            {
                nextlandposZ[i] = nextlandposZ[i - 1] + ConstobsDiff;
                int numobstospawn = Random.Range(0, 4);
                for (int j = 0; j < numobstospawn; j++)
                {
                    if (j == 0)
                    {
                        obsposz = Random.Range(nextlandposZ[i - 1] + 3, nextlandposZ[i] - 3);
                        obstacles[currentobsindex].transform.position = new Vector3(0, 0, obsposz);
                        currentobsindex++;
                    }
                    else
                    {
                        if ((obstacles[currentobsindex - 1].transform.position.z + 3) < nextlandposZ[i] - 3)
                        {
                            obsposz = Random.Range(obstacles[currentobsindex - 1].transform.position.z + 3, nextlandposZ[i] - 3);
                            obstacles[currentobsindex].transform.position = new Vector3(0, 0, obsposz);
                            currentobsindex++;

                        }
                        else
                        {
                            Debug.LogError("overlap");
                            break;

                        }

                    }
                    /* obsposz = Random.Range(nextlandposZ[i - 1] + 3, nextlandposZ[i] - 3);
                    // obstacles[currentobsindex].transform.position = new Vector3(0, 0, obsposz);
                    //currentobsindex++;
                    float prvobsZ = obstacles[currentobsindex - 1].transform.position.z;
                    float ObsZdiff = obsposz - prvobsZ;
                    float obsZdiffabs = Mathf.Abs(ObsZdiff);
                     if(obsZdiffabs>3)
                     {
                         obstacles[currentobsindex].transform.position = new Vector3(0, 0, obsposz);
                         currentobsindex++;
                     }
                     else
                     {

                     }*/

                }
            }




        }

        

    }





}
