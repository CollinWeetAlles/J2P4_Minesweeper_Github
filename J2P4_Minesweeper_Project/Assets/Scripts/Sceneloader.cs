using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour
{
    public void StartGameEasy()
    {
        SceneManager.LoadScene("Easy");
    }
    public void StartGameMedium()
    {
        SceneManager.LoadScene("Medium");
    }
    public void StartGameHard()
    {
        SceneManager.LoadScene("Hard");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartScreen");
        }
    }
}
