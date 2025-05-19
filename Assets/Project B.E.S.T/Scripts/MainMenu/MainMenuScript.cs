using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1); //Can add "BaseLevel", or whatever instead of the scene index
    }
    public void QuiteGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
