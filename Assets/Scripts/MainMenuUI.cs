using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void Continue()
    {
        //TODO ���� ���� ������� ��� �� ����� ��������        
        SceneManager.LoadScene(SaveManager.Instance.GlobalSave.CountOpenLevel + 1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
