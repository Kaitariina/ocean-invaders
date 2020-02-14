using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MED1 : MonoBehaviour
{
    private float fireMIN = 1f;
    private float fireMAX = 3f;
    private float fireNEXT;
    private float speed;

    private const int maxlife = 10;
    private int currentlife = maxlife;

    private bool started = false;

    public RectTransform hpbar;
    public GameObject bubble;

    private Rigidbody2D rb;
    
    void Start()
    {
        fireNEXT = 0;
        string name = SceneManager.GetActiveScene().name;

        if (name == "LVL1")
        {
            speed = 1;
        }
        else
        {
            speed = 1.5f;
        }

        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1, 0) * speed;

        fireNEXT = Time.time + Random.Range(fireMIN, fireMAX);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            started = true;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        Debug.DrawRay(transform.position, Vector2.down, Color.yellow, 0.1f);

        if (hit.collider != null)
        {
            if (!hit.collider.CompareTag("Enemy") || !hit.collider.CompareTag("Enemy2"))
            {
                if (started && Time.time > fireNEXT)
                {
                    fireNEXT += Random.Range(fireMIN, fireMAX);
                    Launch();
                }
            }
        }
    }

    void LaneSwitch()
    {
        Vector2 pos = transform.position;
        pos.y -= 1;
        transform.position = pos;
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
        hpbar.sizeDelta = new Vector2(currentlife * 2.5f, hpbar.sizeDelta.y);

        if (currentlife <= 5)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.05f;
        }

        if (currentlife < 0)
        {
            Destroy(gameObject);
        }

        StartCoroutine(Waitfor(0.1f));
    }

    IEnumerator Waitfor(float i)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
        yield return new WaitForSeconds(i);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("WallLeft"))
        {
            LaneSwitch();
            Turn(1);
        }
        else if (col.gameObject.CompareTag("WallRight"))
        {
            LaneSwitch();
            Turn(-1);
        }

        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Crabster>().Damage(2);
        }
    }

    void Launch()
    {
        GameObject Bubble1 = Instantiate(bubble, (transform.position) + Vector3.up * 0.5f, Quaternion.identity);

        EnemyBubble bub1 = Bubble1.GetComponent<EnemyBubble>();
        bub1.Launch(-transform.up, 300);
    }
}

