using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScene : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1280,720, false);
    }
    
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
