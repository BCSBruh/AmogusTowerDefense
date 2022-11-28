using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;

    public GameObject gameOverUI;

    private void Start()
    {
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver)
            return;

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }

        if (Input.GetKeyDown("e"))
            EndGame();

        if (Input.GetKeyDown("m") && Input.GetKeyDown("o"))
            PlayerStats.money = 9999999;

        if (Input.GetKeyDown("l"))
        {
            SpawnManager spawn = new SpawnManager();
            spawn.SkipWave();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
