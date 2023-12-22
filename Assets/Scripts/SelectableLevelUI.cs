using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectableLevelUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;
    [SerializeField] private string _nameLevel;
    public event Action<string> OnSelectLevel;

    private void Start()
    {
        _button.onClick.AddListener(SelectedLevel);
    }
    private void OnDestroy()
    {
        _button.onClick.RemoveListener(SelectedLevel);
    }
    public void SelectedLevel()
    {
        Debug.Log($"click button {_nameLevel}");
        OnSelectLevel.Invoke(_nameLevel);
    }
}
