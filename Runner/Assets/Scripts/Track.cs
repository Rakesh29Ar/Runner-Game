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
        Obsrandpos();
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

    public void Obsrandpos()
    {

        int index = 1;
        float firstlandpos;
        firstlandpos = 1.56f;
        int currentobsindex = 0;


        nextlandposZ[0] = firstlandpos;
        for (int i = 1; i < 16; i++)
        {
            
            nextlandposZ[i] = nextlandposZ[i - 1] + ConstobsDiff;
            int numobstospawn = Random.Range(0, 5);
            for(int j=0;j<numobstospawn;j++)
            {
                float obsposz = Random.Range(nextlandposZ[i - 1] + 3, nextlandposZ[i] - 3);
                obstacles[currentobsindex].transform.position = new Vector3(0, 0, obsposz);
                currentobsindex++;
            }

         

        }

        

    }





}
