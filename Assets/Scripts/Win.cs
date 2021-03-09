using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    #region UI
    public TMP_Text score;
    public GameObject winPanel;
    public Button play;
    public Button retry;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinLevel()
    {
        winPanel.SetActive(true);
    }
}
