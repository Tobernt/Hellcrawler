using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int sceneBuildIndex;
    public void GameOver()
    {
        Debug.Log("Game Ended!");

        RestartGame();
    }
    public void RestartGame()
    {
        /*if (== "Restart Game")

        /*if (Button == "Restart Game")

        {
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }*/
    }
}
