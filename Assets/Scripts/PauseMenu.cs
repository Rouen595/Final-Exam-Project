using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    public int score = 0;
    public float timeLimit = 0f;
    public float timeRemain = 0f;
    public string name = "";
    public int lives;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text timeLimitText;
    [SerializeField]
    private Text timeRemainText;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text livesText;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void NewGame()
    {
        Menu.username = "Player";
        Score.CurrentScore = 0;
        ChooseNumLives.numLives = 1;
        ChangeSpeed.rTime = ChangeSpeed.gTime;

        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        //Time.timeScale = 1f;
        Score.CurrentScore = 0;
        ChooseNumLives.numLives = 1;

        Menu.username = "Player";
        SceneManager.LoadScene("1Intro");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }

    public void SaveGame()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        /*
        Name.username = "Player";
        Score.PinCount = 0;
        RotatorSpeed.rSpeed = 1f;
        


        nameText.text = Name.username;
        scoreText.text = "Score: " + Score.PinCount;
        */

        Debug.Log("Game Saved");

    }

    public void SaveAsJSON()
    {
        Save save = CreateSaveGameObject();
        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON: " + json);
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            Score.CurrentScore = 0;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            //nameText.text = save.name;
            //scoreText.text = "Score: " + save.score;
            //timeRemainText.text = "Time Remaining: " + save.timeRemain;
            //timeLimitText.text = "Time Limit: " + save.timeLimit;
            //livesText.text = "Lives: " + save.lives;

            Menu.username = save.name;
            Score.CurrentScore = save.score;
            ChooseNumLives.numLives = save.lives;
            ChangeSpeed.gTime = save.timeLimit;
            ChangeSpeed.rTime = save.timeRemain;

            Debug.Log("Game Loaded");

            Resume();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        save.score = Score.CurrentScore;
        save.name = Menu.username;
        save.lives = ChooseNumLives.numLives;
        save.timeLimit = ChangeSpeed.gTime;
        save.timeRemain = GameManager.timeRemaining;


        return save;

    }

}
