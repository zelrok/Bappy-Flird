using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text scoreText;
    public Text scoreTextHigh;
    public GameObject gameOverScreen;
    public AudioSource dingSFX;
    public AudioSource gameOverSFX;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore",0);
        scoreTextHigh.text = highScore.ToString();
    }

    [ContextMenu("Wipe PlayerPrefs")]
    public void wipePrefs()
    {
        // Removes all keys and values from the preferences. Use with caution.
        PlayerPrefs.DeleteAll();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (gameOverScreen.activeSelf == false)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            dingSFX.Play();
        }
    }

    public void restartGame()
    {
        gameOverScreen.SetActive(false);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("SampleScene");
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        gameOverSFX.Play();
        Debug.Log("playerscore" + playerScore.ToString());
        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("highScore", playerScore);
            scoreTextHigh.text = playerScore.ToString();
        }
    }

}
