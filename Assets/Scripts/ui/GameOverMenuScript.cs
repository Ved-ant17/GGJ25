using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverMenuScript : MonoBehaviour
{
    public GameObject gameOverUI;

    public void gameOver()
    {
        gameOverUI.SetActive(true); 
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("FrontScreen");
    }

        public void loadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
