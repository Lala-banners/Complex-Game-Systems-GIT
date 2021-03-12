using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region UI
    [Header("Win")]
    public TMP_Text scoreText;
    public float score;
    public GameObject winPanel;
    public GameObject collect;

    [Header("Main")]
    public Button play;
    public Button retry;
    public Button quit;
    public GameObject startMenu;

    [Header("Game Over")]
    public GameObject gameOver;
    #endregion

    public void WinLevel()
    {
        winPanel.SetActive(true);
        startMenu.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 0;
        scoreText.text = score.ToString();
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            WinLevel();
        }
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        gameOver.SetActive(false);
        winPanel.SetActive(false);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
        startMenu.SetActive(false);
        gameOver.SetActive(false);
        winPanel.SetActive(false);
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        //Collectables
        if(other.gameObject.tag == "Player")
        {
            UpdateScore();
        }
    }



}
