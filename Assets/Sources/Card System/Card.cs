using UnityEngine;


public class Card : MonoBehaviour
{
    [SerializeField] private string _cardName;
    [SerializeField] private string _cardDescription;
    [SerializeField] private Sprite _cardPortrait;

    public int _moneyImpact;
    [SerializeField] private int _incomeImpact;
    [SerializeField] private int _corruptionImpact;
    [SerializeField] private int _reputationImpact;
    
}
