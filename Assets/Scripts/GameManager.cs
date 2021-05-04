// final
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text timeLimitText;
    public Text remainingTimeText;

    public static float timeRemaining;

    bool gameHasEnded = false;

    public float restartDelay = 0.01f;


    public GameObject completeLevelUI;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("YOU DIED");
            //restart game
            Restart();
        }

    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncrementScore()
    {
        Score.CurrentScore++;
    }

    public void DecrementScore()
    {
        Score.CurrentScore--;
    }

    public void IncrementLives()
    {
        ChooseNumLives.numLives++;
    }

    public void DecrementLives()
    {
        ChooseNumLives.numLives--;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    //time manager
  

    // Start is called before the first frame update
    void Start()
    {
        if (ChangeSpeed.rTime > 0)
        {
            timeRemaining = ChangeSpeed.rTime;
        }
        else
        {
            timeRemaining = 10.0f;
        }

        timeLimitText.text = "Time Limit: " + ChangeSpeed.gTime.ToString();
        remainingTimeText.text = "Time Remaining: " + timeRemaining.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining >= 0)
        {
            remainingTimeText.text = "Time Remaining: " + timeRemaining.ToString("F2");
        }
        else
        {
            remainingTimeText.text = "Game Over";
            Invoke("TimeUp", 2.0f);
        }
    }

    void TimeUp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    




}
