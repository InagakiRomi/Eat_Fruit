using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScene : MonoBehaviour
{
    public void StartGame(string SceneName){
        SceneManager.LoadScene(SceneName);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameQuit(){
        Application.Quit();
    }
}
