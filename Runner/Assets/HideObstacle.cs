using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObstacle : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }
}
