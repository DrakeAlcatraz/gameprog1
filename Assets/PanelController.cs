using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{

    public GameObject gameOverPanel;

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameAreaScene");
    }
}
