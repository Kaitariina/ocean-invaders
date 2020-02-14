using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBubble : MonoBehaviour
{
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void Launch(Vector2 dir, float force)
    {
        rb.AddForce(dir * force);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("WallRight") || col.CompareTag("WallLeft"))
        {
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            col.gameObject.GetComponent<Crabster>().Damage(1);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}