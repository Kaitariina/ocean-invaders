using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBubble : MonoBehaviour
{
    private GameObject status;
    private Rigidbody2D rb;

    float timeToLive = 4f;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = Vector2.up * speed;
    }

    void Start()
    {
        status = GameObject.Find("GameStatus");
        Destroy(gameObject, timeToLive);
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

        if (col.gameObject.CompareTag("Miniboss"))
        {
            col.gameObject.GetComponent<EnemyBabies>().Die();
            Destroy(gameObject);
            UpdateScore(10);
        }

        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<MED1>().Die();
            Destroy(gameObject);
            UpdateScore(10);
        }

        if (col.gameObject.CompareTag("Enemy2"))
        {
            col.gameObject.GetComponent<MED2>().Die();
            Destroy(gameObject);
            UpdateScore(10);
        }

        if (col.gameObject.CompareTag("BOSS"))
        {
            col.gameObject.GetComponent<EnemyBoss>().Die();
            Destroy(gameObject);
            UpdateScore(10);
        }

        if (col.gameObject.CompareTag("Shield"))
        {
            {
                Destroy(gameObject);
                Destroy(col.gameObject);
            }
        }
    }

    public void UpdateScore(int points)
    {
        GameManager.points += points;

        status.GetComponent<GameStatus>().AddScore(points);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
    