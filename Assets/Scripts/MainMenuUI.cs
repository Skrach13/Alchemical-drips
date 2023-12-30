using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void Continue()
    {
        //TODO надо этот процесс как то лучше оформить        
        SceneManager.LoadScene(SaveManager.Instance.GlobalSave.CountOpenLevel + 1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
