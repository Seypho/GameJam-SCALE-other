using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    public int playerLives = 3;
    [SerializeField] int maxLive = 3;

    [SerializeField] GameObject[] hearts;
    int currentScore = 0;

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 0)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession(1);
        }
    }

    void TakeLife()
    {
        playerLives--;
        hearts[playerLives].SetActive(false);

    }

    public void AddLife(int value)
    {
        if (hearts.Length < maxLive)
        {
            playerLives += value;
            hearts[playerLives-1].SetActive(true);
        }
    }

    public void ResetGameSession(int scene)
    {
        FindFirstObjectByType<ScenePersist>().DestroyScenePersist();
        SceneManager.LoadScene(scene);
        Destroy(gameObject);
    }


    public void ProcessScore(int value)
    {
        currentScore += value;
    }

}
