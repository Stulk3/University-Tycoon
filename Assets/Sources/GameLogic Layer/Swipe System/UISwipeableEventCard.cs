using UnityEngine;
using UnityEngine.UI;
using CardSystem;
using TMPro;
using System.Collections.Generic;
using System;

namespace SwipeableView
{
    public class UISwipeableEventCard : MonoBehaviour
    {
        [SerializeField]
        private EventCardData _eventCardData;
        [SerializeField]
        private TMP_Text _title;
        
        [SerializeField]
        private TMP_Text _description;

        [SerializeField]
        private TMP_Text _keyWords;

        [SerializeField]
        private TMP_Text _quests;

        [SerializeField]
        private Image _portrait;

        private DialogueVertexAnimator _dialogueVertexAnimator;
        private void Awake()
        {
            if (_eventCardData)
            {
                ExctractDataFromEventCardData();
            }   
        }
        private Coroutine typeRoutine = null;
        

        void PlayStringLine(string message)
        {
            this.EnsureCoroutineStopped(ref typeRoutine);
            _dialogueVertexAnimator.textAnimating = false;
            List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
            typeRoutine = StartCoroutine(_dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, null, null));
        }
        public void ActivateCardEvent(EventDirection direction)
        {
            if(direction == EventDirection.Right || direction == EventDirection.LeftAndRight)
            {
                University.instance.MakeImpact(_eventCardData.RightCardEvent);
            }
            else if (direction == EventDirection.Left || direction == EventDirection.LeftAndRight)
            {
                University.instance.MakeImpact(_eventCardData.LeftCardEvent);
            }
        }

        public void SetEventCardData(EventCardData data)
        {
            _eventCardData = data;
        }
        public void ExctractDataFromEventCardData()
        {
            ExctractPortrait(_eventCardData);
            ExctractTitle(_eventCardData);
            ExctractDesciption(_eventCardData);
            ExctractKeywords(_eventCardData);
        }

        private void ExctractPortrait(EventCardData cardData)
        {
            _portrait.sprite = cardData.Portrait;
            _portrait.gameObject.SetActive(true);
        }

        private void ExctractTitle(EventCardData cardData)
        {
            _title.text = cardData.Title;
        }
        private void ExctractDesciption(EventCardData cardData)
        {
            _description.text = cardData.Description;
        }
        
        private void ExctractKeywords(EventCardData cardData)
        {
            _dialogueVertexAnimator = new DialogueVertexAnimator(_keyWords, null);
            if (cardData.keyWords != null)
            {
                if(cardData.keyWords.Length == 1)
                {
                    PaintKeyword(cardData.keyWords[0]);
                    PlayStringLine(cardData.keyWords[0].Title);
                    //_keyWords.text = cardData.keyWords[0].Title;
                }
                else
                {
                    //CombineKeywords(cardData.keyWords);
                }
            }
        }
        private void PaintKeyword(KeyWord keyWord)
        {
            

        }
       
    }
}