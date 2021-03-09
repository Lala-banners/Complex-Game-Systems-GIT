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

    [Header("Game Over")]
    public GameObject gameOver;
    #endregion

    public void WinLevel()
    {
        winPanel.SetActive(true);
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
        gameOver.SetActive(false);
        winPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
        gameOver.SetActive(false);
        winPanel.SetActive(false);
    }

    public void Collectables()
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

        }
    }



}
