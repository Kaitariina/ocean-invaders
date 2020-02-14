using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private GameObject status;
    public GameObject pauseMenu;

    public Text score;
    public Text endScore;

    private bool paused = false;
    public static int points;

    private void Start()
    {
            status = GameObject.Find("GameStatus");
            points = 0;
    }

    private void Update()
    {
        ShowScore();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                paused = true;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                paused = false;
            }
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MAIN");
        Time.timeScale = 1;
    }

    public void ShowScore()
    {
        score.text = points.ToString();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void ShowTotalScore()
    {
        Scene curscene = SceneManager.GetActiveScene();

        if (curscene.name == "LVL3")
        {
            int totalScore = status.GetComponent<GameStatus>().LoadScore();
            endScore.text = "Total score: \n" + totalScore;
            //tähän että näyttää scoren tekstielementissä
        }
    }
}
