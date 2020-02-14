using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    public static GameStatus status;
    public string currentLevel;
    public int levelProgress;
    public int levelNum;
    public int totalScore;

    public Text save;

    public static string levelKey = "Highest level";
    public static string score = "Score";

    private void Start()
    {
        Load();

        if (PlayerPrefs.HasKey(levelKey))
        {
            levelNum = PlayerPrefs.GetInt(levelKey);
        }
        else
        {
            PlayerPrefs.SetInt(levelKey, 0);
            PlayerPrefs.Save();
        }

        LoadScore();

        if (PlayerPrefs.HasKey(score))
        {
            PlayerPrefs.SetInt(score, 0);
        }
    }

    private void Update()
    {
        currentLevel = SceneManager.GetActiveScene().name;
        levelNum = PlayerPrefs.GetInt(levelKey);
    }

    public void Save()
    {
        if(currentLevel == "LVL1")
        {
            PlayerPrefs.SetInt(levelKey, 1);
            PlayerPrefs.Save();
        }

        if (currentLevel == "LVL2")
        {
            PlayerPrefs.SetInt(levelKey, 2);
            PlayerPrefs.Save();
        }

        if (currentLevel == "LVL3")
        {
            PlayerPrefs.SetInt(levelKey, 3);
            PlayerPrefs.Save();
        }

        StartCoroutine(ShowMessage());

    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt(score, totalScore);
        PlayerPrefs.Save();
    }

    public int Load()
    {
        levelNum = PlayerPrefs.GetInt(levelKey);
        return levelNum;
    }

    public void AddScore(int scoretoAdd)
    {
        totalScore += scoretoAdd;
        SaveScore();
    }

    public int LoadScore()
    {   
        totalScore = PlayerPrefs.GetInt(score);
        return totalScore;
    }

    public void ResetLevel()
    {
        PlayerPrefs.SetInt(levelKey, 0);
        PlayerPrefs.Save();
    }

    IEnumerator ShowMessage()
    {
        save.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        save.gameObject.SetActive(false);
    }

    public void UnlockLevels()
    {
        PlayerPrefs.SetInt(levelKey, 3);
        PlayerPrefs.Save();
    }
}
