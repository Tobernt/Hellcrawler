using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public Transform player;
    public TMP_Text GameOverHighscore;

    private float highscore = 0f;

    private void Start()
    {
        highscore = PlayerPrefs.GetFloat("Highscore", 0f);
        UpdateHighscoreText();
    }
    void Update()
    {
        float playerPositionY = player.position.y;

        scoreText.text = "Score: " + player.position.y.ToString("0");

        if (playerPositionY > highscore)
        {
            highscore = playerPositionY;
            UpdateHighscoreText();
            GameOverScore();

            PlayerPrefs.SetFloat("Highscore: ", highscore);
            PlayerPrefs.Save();
        }
    }
    void UpdateHighscoreText()
    {
        highscoreText.text = "Highscore: " + highscore.ToString("0");
    }
    void GameOverScore()
    {
        GameOverHighscore.text = "Highscore: " + highscore.ToString("0");
    }
}
