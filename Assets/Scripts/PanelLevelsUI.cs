using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelLevelsUI : MonoBehaviour
{
    [SerializeField] private string _levelName;
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _levelConfirmationPanel;
    [SerializeField] private List<SelectableLevelUI> _levelsUI = new List<SelectableLevelUI>();

    private void Start()
    {
        if (_levelConfirmationPanel.activeSelf == true)
        {
            _levelConfirmationPanel.SetActive(false);
        }
        foreach (SelectableLevelUI level in GetComponentsInChildren<SelectableLevelUI>())
        {
            _levelsUI.Add(level);
            level.OnSelectLevel += SelectedLevel;
        }
    }
    private void OnDestroy()
    {
        if (_levelsUI.Count > 0)
        {
            foreach (SelectableLevelUI level in _levelsUI)
            {
                level.OnSelectLevel -= SelectedLevel;
            }
        }
    }
    public void SelectedLevel(string nameLevel)
    {
        _levelName = nameLevel;
        _levelConfirmationPanel.SetActive(true);
        _image.gameObject.SetActive(true);
    }
    public void StartLevel()
    {
        SceneManager.LoadScene(_levelName);
    }
}
