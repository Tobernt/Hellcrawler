using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Loadcheckpoint()
    {
        SceneManager.LoadScene(8);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
