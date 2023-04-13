using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventDirection
{
    LeftAndRight,
    Left,
    Right,
    Down,
    Up
}
[System.Serializable]
public class CardEvent
{
    [SerializeField] private string _quote;

    [SerializeField] private int _moneyImpact;
    [SerializeField] private int _incomeImpact;
    [SerializeField] private int _corruptionImpact;
    [SerializeField] private int _reputationImpact;
    [SerializeField] private int _studentsImpact;

    [SerializeField] private EventDirection _eventDirection;
    

    public string quote => _quote;
    public int moneyImpact => _moneyImpact;
    public int incomeImpact => _incomeImpact;
    public int corruptionImpact => _corruptionImpact;
    public int reputationImpact => _reputationImpact;
    public int studentsImpact => _studentsImpact;
    public EventDirection EventDirection =>_eventDirection;


    public void SetEventDirection(EventDirection direction)
    {
        _eventDirection = direction;
    }
}
