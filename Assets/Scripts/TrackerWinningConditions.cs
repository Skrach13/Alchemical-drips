using System;
using System.Collections.Generic;
using UnityEngine;

public class TrackerWinningConditions : SingletonBase<TrackerWinningConditions>
{
    [SerializeField] private List<VictoryCondition> _victoryConditions;

    public event Action OnVictory;

    private void Start()
    {
        foreach (VictoryCondition condition in _victoryConditions)
        {
            condition.isFulfilledcondition += CheckedVictory;
        }
    }

    private void CheckedVictory(bool isVictory)
    {
        int countConditionVictory = 0;
        foreach (VictoryCondition condition in _victoryConditions)
        {
            if (condition.IsVictory != false)
            {
                countConditionVictory++;
            }
        }
        if (countConditionVictory == _victoryConditions.Count)
        {
            OnVictory.Invoke();
        }
    }
}
