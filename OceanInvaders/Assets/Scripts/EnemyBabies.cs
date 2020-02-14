using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBabies : MonoBehaviour
{
    public GameObject bubble;
    public RectTransform hpbar;

    private Rigidbody2D rb;

    private float fireMIN = 1f;
    private float fireMAX = 3f;
    private float fireNEXT;
    private float health = 10;
    private float speed;

    void Start()
    {
        speed = Random.Range(1, 2.3f);

        fireNEXT = Time.time + Random.Range(fireMIN, fireMAX);
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1, 0) * speed;
    }

    void Update()
    {
        hpbar.sizeDelta = new Vector2(health * 2.5f, hpbar.sizeDelta.y);

        if (Time.time > fireNEXT)
        {
            fireNEXT += Random.Range(fireMIN, fireMAX);
            Launch();
        }
    }

    void Launch()
    {
        GameObject Bubble1 = Instantiate(bubble, (transform.position) + Vector3.up * 0.5f, Quaternion.identity);

        EnemyBubble bub1 = Bubble1.GetComponent<EnemyBubble>();
        bub1.Launch(-transform.up, 300);
    }

    public void Die()
    {
        health--;
        StartCoroutine(Waitfor(0.1f));

        if (health <= 0) { 
            Destroy(gameObject, 0.3f);
        }
    }

    IEnumerator Waitfor(float i)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
        yield return new WaitForSeconds(i);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void Turn(int dir)
    {
        Vector2 newVelo = rb.velocity;
        newVelo.x = speed * dir;
        rb.velocity = newVelo;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("WallLeft"))
        {
            Turn(1);
        }
        else if (col.gameObject.CompareTag("WallRight"))
        {
            Turn(-1);
        }

        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Crabster>().Damage(2);
        }
    }
}
