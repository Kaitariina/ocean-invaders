using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHolder : MonoBehaviour
{
    public GameObject playMenu;
    public GameObject won;

    private GameObject tip1;
    private GameObject manager;

    private int ogAmountOfEnemies;

    Scene curscene;

    void Start()
    {
        curscene = SceneManager.GetActiveScene();

        manager = GameObject.Find("GameMana");
        ogAmountOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length + GameObject.FindGameObjectsWithTag("Enemy2").Length;
    }

    void Update()
    {
        if (transform.childCount < 1)
        {
            playMenu.SetActive(true);
            won.SetActive(true);
            manager.GetComponent<GameManager>().ShowTotalScore();
        }

        //int amountOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length + GameObject.FindGameObjectsWithTag("Enemy2").Length;

        //if (amountOfEnemies < (ogAmountOfEnemies / 2))
        //{
        //    enemy.GetComponent<Enemy>().AddSpeed(1.5f);
        //}

        if (curscene.name == "LVL1" && transform.childCount < 1)
        {
            tip1 = GameObject.Find("Tutorial").gameObject.transform.GetChild(0).gameObject;
            tip1.SetActive(false);
        }
    }
}
