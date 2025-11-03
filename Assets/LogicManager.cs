using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicManager : MonoBehaviour
{
  public int playerScore;
  public Text scoreText;
  public GameObject GameOverScreen;

    [ContextMenu("Add 1 to Score")]
    public void AddScore(int scoreToAdd)
    {         
        playerScore += 1;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    { 
        GameOverScreen.SetActive(true); 
    }    

}
