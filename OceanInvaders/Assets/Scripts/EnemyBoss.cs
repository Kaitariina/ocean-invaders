using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject babies;
    public RectTransform hpbar;
    public GameObject bubble;

    private float speed;
    private const int maxlife = 60;
    private int currentlife = maxlife;
    private int lapsiluku;

    private float fireMIN = 1f;
    private float fireMAX = 3f;
    private float fireNEXT;

    public GameObject[] sp;

    void Start()
    {
        speed = 1;

        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1, 0) * speed;

        fireNEXT = Time.time + Random.Range(fireMIN, fireMAX);
    }

    void Update()
    {
        if (babies)
        {
            lapsiluku = babies.transform.childCount;

        }

        if (Time.time > fireNEXT)
        {
            fireNEXT += Random.Range(fireMIN, fireMAX);
            Launch();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("LimitL"))
        {
            Turn(1);
        }
        else if (col.gameObject.CompareTag("LimitR"))
        {
            Turn(-1);
        }
    }

    void Launch()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject Bubble1 = Instantiate(bubble, (sp[i].transform.position) + Vector3.up * 0.5f, Quaternion.identity);

            EnemyBubble bub1 = Bubble1.GetComponent<EnemyBubble>();
            bub1.Launch(-transform.up, 300);
        }
    }

    void Turn(int dir)
    {
        Vector2 newVelo = rb.velocity;
        newVelo.x = speed * dir;
        rb.velocity = newVelo;
    }

    public void Die()
    {
        currentlife--;
        hpbar.sizeDelta = new Vector2(currentlife * 0.5f, hpbar.sizeDelta.y);

        if (currentlife <= 50)
        {
            if (babies)
            {
                babies.SetActive(true);
            }
        }

        if (currentlife < 0)
        {
            Destroy(gameObject);

            if (lapsiluku == 0 && babies)
            {
                Destroy(babies);
            }
        }

        StartCoroutine(Waitfor(0.1f));
    }

    IEnumerator Waitfor(float i)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        yield return new WaitForSeconds(i);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

}
