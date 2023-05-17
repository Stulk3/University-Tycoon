using UnityEngine;
using UnityEngine.UI;
using CardSystem;

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

        public override void UpdateContent(BasicCardData data)
        {
            _background.color = data.color;

            _imageLeft.alpha = 0;
            _imageRight.alpha = 0;
        }

        protected override void SwipingRight(float rate)
        {
            _imageLeft.alpha = rate;
            _imageRight.alpha = 0;
        }

        protected override void SwipingLeft(float rate)
        {
            _imageRight.alpha = rate;
            _imageLeft.alpha = 0;
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
    }
}