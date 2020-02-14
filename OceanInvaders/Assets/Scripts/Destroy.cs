using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject boss;

    void Update()
    {
        if (!boss && transform.childCount < 1)
        {
            Destroy(gameObject);
        }
    }
}
