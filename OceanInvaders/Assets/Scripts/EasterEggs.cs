using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggs : MonoBehaviour
{
    public GameObject TIP1;
    public GameObject TIP2;

    void Update()
    {
        if (transform.childCount < 1)
        {
            TIP1.SetActive(false);
            TIP2.SetActive(true);
        }
    }
}
