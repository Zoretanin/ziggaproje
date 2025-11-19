using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
  public int playerScore;
  public Text scoreText;
  public GameObject GameOverScreen;
  public bool isPlayer1Dead;
  public bool isPlayer2Dead;

  

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

    public void OnPlayerKill(int playerNumer)
    {
        if (playerNumer == 1)
        {
            isPlayer1Dead = true;
        }
        else if (playerNumer == 2)
        {
            isPlayer2Dead = true;
        }

        if (isPlayer1Dead && isPlayer2Dead)
        {
            gameOver();
        }

    }

}
