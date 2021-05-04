using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int CurrentScore = 0;

    public Text scoreText;
    public GameManager gameManager;

    void Start()
    {
        if (CurrentScore >= 1000)
        {
            Debug.Log("YOU WIN!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
    void Update()
    {
        if (CurrentScore < 0)
        {
            CurrentScore = 0;
        }
        scoreText.text = "Score: " + CurrentScore.ToString();
    }

}
