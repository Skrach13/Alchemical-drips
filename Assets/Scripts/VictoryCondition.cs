using System;
using UnityEngine;

abstract public class VictoryCondition : MonoBehaviour
{
    protected bool _isVictory = false;

    public event Action<bool> isFulfilledcondition;
    public bool IsVictory { get => _isVictory; set => _isVictory = value; }

    protected void IsFulfilledcondition()
    {
        isFulfilledcondition.Invoke(IsVictory);
    }
}
