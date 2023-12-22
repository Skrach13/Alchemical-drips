using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void Continue()
    {
        //TODO
        SceneManager.LoadScene(SaveManager.Instance.GlobalSave.CountOpenLevel);
    }
    public void Exit()
    {
        Application.Quit();
    }    
}
