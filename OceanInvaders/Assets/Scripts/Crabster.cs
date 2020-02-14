using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crabster : MonoBehaviour
{
    [SerializeField]
    private float movemSpeed;
    public int health;

    private AudioSource aS;
    private Rigidbody2D RB;
    Animator animator;

    public GameObject bubble;
    public GameObject proPlaceR;
    public GameObject proPlaceL;

    public GameObject gameMana;
    public GameObject playMenu;
    public GameObject lost;


    public GameObject health4;
    public GameObject health3;
    public GameObject health2;
    public GameObject health1;
    public GameObject health0;

    float startTime;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        aS = GetComponent<AudioSource>();


        movemSpeed = 5;
        health = 5;
    }

    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * movemSpeed * Time.deltaTime, 0,0);

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            animator.SetBool("Walking", true);
        } 
        else 
        {
            animator.SetBool("Walking", false);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)){
            animator.SetTrigger("Squat");
            startTime = Time.time;    
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            float timePressed = Time.time - startTime;
            
            if (timePressed > 2 && health < 5)
            {
                GainHealth();
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
            aS.Play();
        }
     }

    void Launch()
    {
        GameObject Bubble1 = Instantiate(bubble, (proPlaceL.transform.position) + Vector3.up * 0.5f, Quaternion.identity);
        GameObject Bubble2 = Instantiate(bubble, (proPlaceR.transform.position) + Vector3.up * 0.5f, Quaternion.identity);

        PlayerBubble bub1 = Bubble1.GetComponent<PlayerBubble>();
        bub1.Launch(transform.up, 300);

        PlayerBubble bub2 = Bubble2.GetComponent<PlayerBubble>();
        bub2.Launch(transform.up, 300);
    }

    public void GainHealth()
    {
        health++;

        if (health == 5)
        {
            health4.SetActive(true);
            health3.SetActive(true);
            health2.SetActive(true);
            health1.SetActive(true);
            health0.SetActive(true);
        }
        else if (health == 4)
        {
            health3.SetActive(true);
            health2.SetActive(true);
            health1.SetActive(true);
            health0.SetActive(true);
        }
        else if (health == 3)
        {
            health2.SetActive(true);
            health1.SetActive(true);
            health0.SetActive(true);
        }
        else if (health == 2)
        {
            health1.SetActive(true);
            health0.SetActive(true);
        }
        else if (health == 1)
        {
            health0.SetActive(true);
        }
    }

    public void Damage(int dmg)
    {
        health -= dmg;

        if (health == 4)
        {
            health4.SetActive(false);
        }
        else if (health == 3)
        {
            health4.SetActive(false);
            health3.SetActive(false);
        }
        else if (health == 2)
        {
            health4.SetActive(false);
            health3.SetActive(false);
            health2.SetActive(false);

        }
        else if (health == 1)
        {
            health4.SetActive(false);
            health3.SetActive(false);
            health2.SetActive(false);
            health1.SetActive(false);
        }

        if (health <= 0)
        {
            health4.SetActive(false);
            health3.SetActive(false);
            health2.SetActive(false);
            health1.SetActive(false);
            health0.SetActive(false);

            playMenu.SetActive(true);
            lost.SetActive(true);

            Destroy(gameObject, 0.3f);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("HP"))
        {
            if (health < 5)
            {
                GainHealth();
                Debug.Log(health);
            }
            Destroy(col.gameObject);
        }
    }
}
