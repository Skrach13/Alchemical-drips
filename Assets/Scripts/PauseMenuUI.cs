using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuPanel;
    [SerializeField] private GameObject _soundsOptionPanel;

    // Start is called before the first frame update
    void Start()
    {
        _pauseMenuPanel.SetActive(false);
        _soundsOptionPanel.SetActive(false);
    }

    public void ChangePause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            _pauseMenuPanel.SetActive(false);
            _soundsOptionPanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            _pauseMenuPanel.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeSoundsOptionsPanel()
    {
        if (_soundsOptionPanel.activeSelf == true)
        {
            _soundsOptionPanel.SetActive(false);
        }
        else
        {
            _soundsOptionPanel.SetActive(true);
        }
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
