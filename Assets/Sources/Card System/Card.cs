using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class Card
{
    [SerializeField] private string _cardName;
    [TextArea]
    [SerializeField] private string _cardDescription;
    [SerializeField] private Sprite _cardPortrait;

    [SerializeField] private int _moneyImpact;
    [SerializeField] private int _incomeImpact;
    [SerializeField] private int _corruptionImpact;
    [SerializeField] private int _reputationImpact;



    [SerializeField] private UnityEvent cardEvent;
    
}
