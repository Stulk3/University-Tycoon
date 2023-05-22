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

        private void Start()
        {
            _corruptionPreview = UserInterface.CorruptionPreview;
            _studentsPreview = UserInterface.ReputationPreview;
            _moneyPreview = UserInterface.MoneyPreview;
            _incomePreview = UserInterface.IncomePreview;

            _corruptionPreview.alpha = 0;
            _studentsPreview.alpha = 0;
            _moneyPreview.alpha = 0;
            _incomePreview.alpha = 0;
        }
        public override void UpdateContent(BasicCardData data)
        {
            _background.color = data.color;

            _imageLeft.alpha = 0;
            _imageRight.alpha = 0;
            Debug.Log("Update");
        }

        protected override void SwipingRight(float rate)
        {
            _imageLeft.alpha = rate;
            _imageRight.alpha = 0;

            PreviewEventCardImpacts(EventDirection.Right, rate);
        }
        protected override void SwipingLeft(float rate)
        {
            _imageRight.alpha = rate;
            _imageLeft.alpha = 0;

            PreviewEventCardImpacts(EventDirection.Left, rate);
        }
        protected override void OnLeftSwipeEnded()
        {
            _eventCard.ActivateCardEvent(EventDirection.Left);
            University.instance.GetIncome();
        }
        protected override void OnRightSwipeEnded()
        {
            _eventCard.ActivateCardEvent(EventDirection.Right);
            University.instance.GetIncome();
        }
        private void PreviewEventCardImpacts(EventDirection eventDirection, float rate)
        {
            if (_corruptionPreview != null && _eventCard.GetEventCorruptionImpact(eventDirection) != 0)
            {
                _corruptionPreview.text = _eventCard.GetEventCorruptionImpact(eventDirection).ToString();
                _corruptionPreview.alpha = rate;
            }
            if (_studentsPreview != null && _eventCard.GetEventStudentsImpact(eventDirection) != 0)
            {
                _studentsPreview.text = _eventCard.GetEventStudentsImpact(eventDirection).ToString();
                _studentsPreview.alpha = rate;
            }

            if (_moneyPreview != null && _eventCard.GetEventMoneyImpact(eventDirection) != 0)
            {
                _moneyPreview.text = _eventCard.GetEventMoneyImpact(eventDirection).ToString();
                _moneyPreview.alpha = rate;
            }

            if (_incomePreview != null && _eventCard.GetEventIncomeImpact(eventDirection) != 0)
            {
                _incomePreview.text = _eventCard.GetEventIncomeImpact(eventDirection).ToString();
                _incomePreview.alpha = rate;
            }
        }
    }
}