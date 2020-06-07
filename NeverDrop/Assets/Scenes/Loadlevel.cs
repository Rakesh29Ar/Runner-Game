using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadlevel : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        int leveltoload = PlayerPrefs.GetInt("currentlevel",1);
        SceneManager.LoadScene(leveltoload);

    }


}
