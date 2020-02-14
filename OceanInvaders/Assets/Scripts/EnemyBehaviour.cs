using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private int life;
    private int endOf = 1;
    private int speed = 2;

    Animator animator;
    Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();

        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1, 0) * speed;

        life = 10;
    }

    void Update()
    {

        if (life == 9 || life == 8 || life == 7)
        {
            animator.SetBool("DMG1", true);

        }
        else if (life == 6 || life == 5)
        {
            animator.SetBool("DMG1", false);
            animator.SetBool("DMG2", true);

        }
        else if (life == 4 || life == 3)
        {
            animator.SetBool("DMG2", false);
            animator.SetBool("DMG3", true);

        }
        else if (life == 2 || life == 1)
        {
            animator.SetBool("DMG3", false);
            animator.SetBool("DMG4", true);

        }
        else if (life == 0)
        {
            Destroy(gameObject, endOf);
        }

    }

    public void LessLife()
    {
        Debug.Log("LESSLIFEE");
        life -= 1;
        StartCoroutine(Waitfor(0.1f));
    }

    IEnumerator Waitfor(float i)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
        yield return new WaitForSeconds(i);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 1;
        transform.position = position;
    }

    void Turn(int dir)
    {
        Vector2 newVelo = rb.velocity;
        newVelo.x = speed * dir;
        rb.velocity = newVelo;
    }

    private void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("limit")){
            
            if(col.gameObject.name == "limitR")
            {
                Turn(-1);
                MoveDown();
            }
            else
            {
                Turn(1);
                MoveDown();
            }
        }
    }
}