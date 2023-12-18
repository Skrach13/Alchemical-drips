using System;
using UnityEngine;

public class Score : SingletonBase<Score>
{
    [SerializeField] private int _scorePlayer;
    public event Action<int> OnScoreChanged;
    public int ScorePlayer
    {
        get => _scorePlayer;
        set
        {
            _scorePlayer = value;
            OnScoreChanged?.Invoke(_scorePlayer);
            Debug.Log($"{_scorePlayer}");
        }
    }
}
