using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardSystem
{
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
    

        public string Quote => _quote;
        public int MoneyImpact => _moneyImpact;
        public int IncomeImpact => _incomeImpact;
        public int CorruptionImpact => _corruptionImpact;
        public int ReputationImpact => _reputationImpact;
        public int StudentsImpact => _studentsImpact;
        public EventDirection EventDirection =>_eventDirection;


        public void SetEventDirection(EventDirection direction)
        {
            _eventDirection = direction;
        }
    }
}