using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Cards/Quest", order = 3)]
public class Quest : ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField] private Color _color;
    [SerializeField] private EventCardData[] _cards;
    [SerializeField] private Achievement _achievement;
    private int _questProgress = 0;
    public string title => _title;
    public Color color => _color;
    public EventCardData[] cards => _cards;
    public Achievement achievement => _achievement;
    public int questProgress => _questProgress;

    private void Awake()
    {
        _title = "Default";
    }
    private void OnValidate()
    {
        _title = this.name;
        SetQuestToCards(_cards);
    }
    public void Progress()
    {
        _questProgress++;
        if(_cards.Length < _questProgress)
        {
            FinishQuest();
        }
    }
    private void FinishQuest()
    {
        if(_achievement != null)
        {
            _achievement.Done();
        }
    }
    private void SetQuestToCards(EventCardData[] cards)
    {
        if(cards.Length != 0)
        {
            foreach (EventCardData card in cards)
            {
                card.SetQuest(this);
            }
        }
    }
}
