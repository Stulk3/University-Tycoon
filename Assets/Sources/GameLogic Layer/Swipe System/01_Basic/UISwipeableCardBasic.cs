using UnityEngine;
using UnityEngine.UI;
using CardSystem;
using TMPro;

namespace SwipeableView
{
    public class UISwipeableCardBasic : UISwipeableCard<BasicCardData>
    {
        [SerializeField] private UISwipeableEventCard _eventCard;
        [SerializeField]
        private Image _background = default;

        [SerializeField]
        private CanvasGroup _imageLeft = default;

        [SerializeField]
        private CanvasGroup _imageRight = default;

        [SerializeField] private TextMeshProUGUI _corruptionPreview;
        [SerializeField] private TextMeshProUGUI _studentsPreview;
        [SerializeField] private TextMeshProUGUI _moneyPreview;
        [SerializeField] private TextMeshProUGUI _incomePreview;

        [SerializeField] private TextMeshProUGUI _quotePreview;
        private void Start()
        {
            SetPreviews();
            EventDealer.SwapOrFillActiveCardsPool(this);
        }
        private void SetPreviews()
        {
            _corruptionPreview = UserInterface.CorruptionPreview;
            _studentsPreview = UserInterface.ReputationPreview;
            _moneyPreview = UserInterface.MoneyPreview;
            _incomePreview = UserInterface.IncomePreview;
            _quotePreview = UserInterface.QuotePreview;
        }
        public override void UpdateContent(BasicCardData data)
        {
            _background.color = data.color;
            _eventCard.SetEventCardData(data.eventCard);

            _imageLeft.alpha = 0;
            _imageRight.alpha = 0;
        }

        protected override void SwipingRight(float rate)
        {
            _imageLeft.alpha = rate;
            _imageRight.alpha = 0;

            PreviewEventCardQuotes(EventDirection.Right, rate);
            PreviewEventCardImpacts(EventDirection.Right, rate);
        }
        protected override void SwipingLeft(float rate)
        {
            _imageRight.alpha = rate;
            _imageLeft.alpha = 0;

            PreviewEventCardQuotes(EventDirection.Left, rate);
            PreviewEventCardImpacts(EventDirection.Left, rate);
        }
        protected override void OnLeftSwipeEnded()
        {
            _eventCard.ActivateCardEvent(EventDirection.Left);

            University.instance.GetIncome();

            EventDealer.SwapOrFillActiveCardsPool(this);
        }
        protected override void OnRightSwipeEnded()
        {
            _eventCard.ActivateCardEvent(EventDirection.Right);

            University.instance.GetIncome();

            EventDealer.SwapOrFillActiveCardsPool(this);
        }

        private void PreviewEventCardImpacts(EventDirection eventDirection, float rate)
        {
            
            if (_corruptionPreview != null && EventDealer.ActiveCardsPool[0] == this)
            {
                var value = _eventCard.GetEventCorruptionImpact(eventDirection);
                if (value > 0)
                {
                    _corruptionPreview.text = "+" + value.ToString() + "%";
                    _corruptionPreview.color = new Color32(180, 0, 0, 255);
                    _corruptionPreview.alpha = rate;
                }
                else if (value == 0)
                {
                    _corruptionPreview.alpha = 0;
                }
                else if (value < 0)
                {
                    _corruptionPreview.text = value.ToString() + "%";
                    _corruptionPreview.color = new Color32(0, 180, 0, 255);
                    _corruptionPreview.alpha = rate;
                }
            }
            if (_studentsPreview != null && EventDealer.ActiveCardsPool[0] == this)
            {
                var value = _eventCard.GetEventStudentsImpact(eventDirection);
                if (value > 0)
                {
                    _studentsPreview.text = "+" + value.ToString();
                    _studentsPreview.color = new Color32(0, 180, 0, 255);
                    _studentsPreview.alpha = rate;
                }
                else if (value == 0)
                {
                    _studentsPreview.alpha = 0;
                }
                else if (value < 0)
                {
                    _studentsPreview.text = value.ToString();
                    _studentsPreview.color = new Color32(180, 0, 0, 255);
                    _studentsPreview.alpha = rate;
                }
            }

            if (_moneyPreview != null && EventDealer.ActiveCardsPool[0] == this)
            {
                var value = _eventCard.GetEventMoneyImpact(eventDirection);
                if (value > 0)
                {
                    _moneyPreview.text = "+" + value.ToString() + "K";
                    _moneyPreview.color = new Color32(0, 180, 0, 255);
                    _moneyPreview.alpha = rate;
                }
                else if (value == 0)
                {
                    _moneyPreview.alpha = 0;
                }
                else if (value < 0)
                {
                    _moneyPreview.text = value.ToString() + "K";
                    _moneyPreview.color = new Color32(180, 0, 0, 255);
                    _moneyPreview.alpha = rate;
                }
            }

            if (_incomePreview != null && EventDealer.ActiveCardsPool[0] == this)
            {
                var value = _eventCard.GetEventIncomeImpact(eventDirection);
                if (value > 0)
                {
                    _incomePreview.text = "+" + value.ToString() + "K";
                    _incomePreview.color = new Color32(0, 180, 0, 255);
                    _incomePreview.alpha = rate;
                }
                else if (value == 0)
                {
                    _incomePreview.alpha = 0;
                }
                else if (value < 0)
                {
                    _incomePreview.text = value.ToString() + "K";
                    _incomePreview.color = new Color32(180, 0, 0, 255);
                    _incomePreview.alpha = rate;
                }
            }
        }
        private void PreviewEventCardQuotes(EventDirection eventDirection, float rate)
        {

            if (_quotePreview != null && EventDealer.ActiveCardsPool[0] == this)
            {
                string value = _eventCard.GetEventQuote(eventDirection);
                _quotePreview.text = value;
                _quotePreview.alpha = rate;
            }
        }
    }
}