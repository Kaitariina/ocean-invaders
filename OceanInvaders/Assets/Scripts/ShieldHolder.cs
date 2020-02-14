using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHolder : MonoBehaviour
{
    public GameObject hpPack;

    // Create a healtpack once all the objects in the shield group are destroyed
    void Update()
    {
        if(transform.childCount < 1)
        {
            Instantiate(hpPack, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
