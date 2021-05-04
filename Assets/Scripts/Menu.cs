// menu final
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public InputField usernameInput;
    public static string username;


    void Start()
    {
        username = "Player";
    }

    public void SaveUsername(string newName)
    {
        username = newName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
