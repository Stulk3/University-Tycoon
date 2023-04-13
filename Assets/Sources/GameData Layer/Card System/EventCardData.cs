using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace CardSystem
{
    [CreateAssetMenu(fileName = "EventCardData", menuName = "Cards/EventCard Data", order = 1)]
    public class EventCardData : ScriptableObject
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

        public string Title => _title;
        public string Description => _description;
        public Sprite Portrait => _portrait;
        public Sprite Background => _background;
        public CardEvent LeftCardEvent => _leftCardEvent;
        public CardEvent RightCardEvent => _rightCardEvent;
        public CardEvent[] CardEvents => _cardEvents;

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
            if (_quest != null)
            {
                _quest.Progress();
            }
        }

        private void CheckForCardEventArrayOverloading()
        {
            if (_cardEvents.Length > 4)
            {
                _cardEvents = _cardEvents.Take(_cardEvents.Count() - 1).ToArray();
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
                else if (cardEvent.EventDirection == EventDirection.LeftAndRight & _leftCardEvent == null & _rightCardEvent == null)
                {
                    _rightCardEvent = cardEvent;
                    _leftCardEvent = cardEvent;
                }
                else if (cardEvent.EventDirection == EventDirection.LeftAndRight & _leftCardEvent != null & _rightCardEvent != null)
                {
                    _cardEvents = _cardEvents.Take(_cardEvents.Count() - 1).ToArray();
                    Debug.LogWarning("CardData Can't Contain Left and Right Direction Twice");
                }
            }
        }
    }
}