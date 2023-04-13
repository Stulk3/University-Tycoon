using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Cards/CardData", order = 1)]
public class CardData : ScriptableObject
{
    [SerializeField] private string _title;
    [TextArea]
    [SerializeField] private string _description;
    [SerializeField] private Sprite _portrait;
    [SerializeField] private Sprite _background;

    private CardEvent _leftCardEvent;
    private CardEvent _rightCardEvent;

    [SerializeField] private CardEvent[] _cardEvents;
    [SerializeField] private KeyWord[] _keyWords;
    [SerializeField] private Quest _quest;

    public string title => _title;
    public string description => _description;
    public Sprite portrait => _portrait;
    public Sprite background => _background;
    public CardEvent leftCardEvent => _leftCardEvent;
    public CardEvent rightCardEvent => _rightCardEvent;
    public CardEvent[] cardEvents => _cardEvents;

    public KeyWord[] keyWords => _keyWords;
    public Quest quest => _quest;




    private void OnValidate()
    {
        CheckForCardEventArrayOverloading();
        SetCardEvents();
    }

    public void SetQuest(Quest quest)
    {
        _quest = quest;
    }

    public void ProgressQuest()
    {
        if(_quest != null)
        {
            _quest.Progress();
        }
    }

    private void CheckForCardEventArrayOverloading()
    {
        if (cardEvents.Length > 4)
        {
            _cardEvents = cardEvents.Take(_cardEvents.Count() - 1).ToArray();
            throw new System.Exception("CardEvent can contain only 4 directions");
        }
    }
    private void SetCardEvents()
    {
        _leftCardEvent = null;
        _rightCardEvent = null;

        foreach (CardEvent cardEvent in _cardEvents)
        {
            
            if (cardEvent.EventDirection == EventDirection.Left & _leftCardEvent == null)
            {
                _leftCardEvent = cardEvent;
                
            }
            else if (cardEvent.EventDirection == EventDirection.Left & _leftCardEvent != null)
            {
                cardEvent.SetEventDirection(EventDirection.Right);
                Debug.LogWarning("CardData Can Contain Only One Left Direction");
            }
            else if (cardEvent.EventDirection == EventDirection.Right & _leftCardEvent == null)
            {
                _rightCardEvent = cardEvent;
                
            }
            else if (cardEvent.EventDirection == EventDirection.Right & _rightCardEvent != null)
            {
                cardEvent.SetEventDirection(EventDirection.Left);
                Debug.LogWarning("CardData Can Contain Only One Right Direction");
            }
            else if(cardEvent.EventDirection == EventDirection.LeftAndRight & _leftCardEvent == null & _rightCardEvent == null)
            {
                _rightCardEvent = cardEvent;
                _leftCardEvent = cardEvent;
            }
            else if (cardEvent.EventDirection == EventDirection.LeftAndRight & _leftCardEvent != null & _rightCardEvent != null)
            {
                _cardEvents = cardEvents.Take(_cardEvents.Count() - 1).ToArray();
                Debug.LogWarning("CardData Can't Contain Left and Right Direction Twice");
            }
        }
    }
}