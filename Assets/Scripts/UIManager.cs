using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager manager = null;

    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    #region UI
    [Header("Win")]
    public TMP_Text scoreText;
    public float score;
    public GameObject winPanel;
    public GameObject collect;

    [Header("Main")]
    public GameObject startMenu;

    [Header("Game Over")]
    public GameObject gameOver;
    public bool isGameOver = false;
    #endregion

    public void WinLevel()
    {
        if (score == 3) //Number of collectables and if won is true
        {
            isGameOver = false;
            winPanel.SetActive(true);
            startMenu.SetActive(false);
            gameOver.SetActive(false);
            scoreText.text = score.ToString();
        }
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
        startMenu.SetActive(false);
        score = 0;
        winPanel.SetActive(false);
        gameOver.SetActive(false);
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOver.SetActive(true);
        scoreText.text = score.ToString();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
