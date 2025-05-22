using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    public static PanelController instance;
    public GameObject gameOverPanel;
    public GameObject PausePanel;
    public GameObject LevelUpPanel;
    public LevelUpButton1[] levelUpButtons;
    public Levelupbutton2[] levelUpButtons2;
    public LevelUpbutton3[] levelUpbutton3rd;


void Awake()
{
    instance = this;
}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameAreaScene");
    }

    public void pause()
    {
        if (PausePanel.activeSelf == false && gameOverPanel.activeSelf == false)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void OpenLevelUpPanel()
    {
        LevelUpPanel.SetActive(true);
        Time.timeScale = 0f;
    }

      public void closeLevelUpPanel()
    {
        LevelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
