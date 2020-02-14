using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVLSelect : MonoBehaviour
{
    public GameObject button2;
    public GameObject button3;
    public GameObject lvlSelect;

    private GameObject status;

    private int level;

    void Start()
    {
        status = GameObject.Find("GameStatus");
    }

    void Update()
    {
        level = status.GetComponent<GameStatus>().Load();

        if (level == 3)
        {
            button2.SetActive(true);
            button3.SetActive(true);
        }

        if (level == 2)
        {
            button2.SetActive(true);
            button3.SetActive(true);
        }

        if (level == 1)
        {
            button2.SetActive(true);
            button3.SetActive(false);
        }
                
        if (level == 0)
        {
            button2.SetActive(false);
            button3.SetActive(false);
        }
    }
}