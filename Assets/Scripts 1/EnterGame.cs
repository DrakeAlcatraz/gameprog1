using UnityEngine;
using UnityEngine.SceneManagement;
public class EnterGame : MonoBehaviour
{
    public void activateButton()
    {
        SceneManager.LoadScene("GameAreaScene");
   }
}
