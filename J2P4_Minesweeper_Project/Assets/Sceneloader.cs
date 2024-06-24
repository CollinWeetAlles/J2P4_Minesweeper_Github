using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
