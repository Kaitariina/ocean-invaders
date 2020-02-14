using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D projectileRB;

    float timeToLive = 4f;

    void Awake()
    {
        projectileRB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, timeToLive);
    }

    public void Launch(Vector2 dir, float force)
    {
        projectileRB.AddForce(dir * force);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("VIHU");

            col.gameObject.GetComponent<MED2>().Die();
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Shelter"))
        {
            Destroy(gameObject);
        }
    }
}
