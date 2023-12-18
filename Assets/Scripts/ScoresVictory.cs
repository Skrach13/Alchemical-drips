using System;
using UnityEngine;

public class ScoresVictory : VictoryCondition
{
    [SerializeField] private int _neededScore;   

    private void Start()
    {
        Score.Instance.OnScoreChanged += CheckingCondition;
    }
    private void OnDestroy()
    {
        Score.Instance.OnScoreChanged += CheckingCondition;
    }    

    private  void CheckingCondition(int score)
    {
        if(score >= _neededScore && IsVictory == false)
        {
            IsVictory = true;
            IsFulfilledcondition();
        }
    }
}
