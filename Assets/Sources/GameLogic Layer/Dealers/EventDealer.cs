using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardSystem;
using SwipeableView;
using System.Linq;

public class EventDealer : MonoBehaviour
{
    public static EventDealer instance;

    private bool _isPrologueComplete;
    public bool isPrologueComplete => instance._isPrologueComplete;

    [SerializeField] private EventCardData[] _prologuePool;
    [SerializeField] private int prologueCardIndex = 0;


    [SerializeField] private UISwipeableViewBasic _swipeableView = default;

    [SerializeField] private UISwipeableCardBasic[] _activeCardsPool; 
    
    [SerializeField] private EventCardData[] _eventCards;
    [Space(2f)]
    [SerializeField] private EventCardData[] _eventCardsPool;

    [SerializeField] private KeyWord[] _keyWords;
    [SerializeField] private Quest[] _quests;

    public static UISwipeableCardBasic[] ActiveCardsPool => instance._activeCardsPool;
    public EventCardData[] eventCards => _eventCards;
    public EventCardData[] eventCardsPool => _eventCardsPool;
    public KeyWord[] keyWords => _keyWords;
    public Quest[] quests => _quests;
    public UISwipeableViewBasic SwipeableView => instance._swipeableView;


    private void Awake()
    {
        instance = this;
        _activeCardsPool = new UISwipeableCardBasic[2] { null, null };
    }
    private void Start()
    {
        if (isPrologueComplete)
        {
            var data = Enumerable.Range(0, 5)
            .Select(i => new BasicCardData
            {
                color = new Color(Random.value, Random.value, Random.value, 1.0f)
            })
            .ToList();

            _swipeableView.UpdateData(data);
        }
        else
        {

            var data = Enumerable.Range(0, 5)
            .Select(i => new BasicCardData
            {
                color = new Color(Random.value, Random.value, Random.value, 1.0f),
                eventCard = FillEventCard(_prologuePool)
            })
            .ToList();

            _swipeableView.UpdateData(data);

            SwapOrFillActiveCardsPool(_activeCardsPool[1]);
        }
        
    }
    private EventCardData FillEventCard(EventCardData[] cards)
    {
        prologueCardIndex++;
        return cards[prologueCardIndex-1];
    }

    public static void SwapOrFillActiveCardsPool(UISwipeableCardBasic card)
    {
        if (instance._activeCardsPool[0] == null && instance._activeCardsPool[1] == null)
        {
            instance._activeCardsPool[0] = card;
        }
        else if (instance._activeCardsPool[0] != null && instance._activeCardsPool[1] == null)
        {
            instance._activeCardsPool[1] = card;
        }
        else
        {
            var temp = instance._activeCardsPool[0];
            instance._activeCardsPool[0] = instance._activeCardsPool[1];
            instance._activeCardsPool[1] = temp;
        }
    }
    public void ShuffleEventCardsPool()
    {
        _eventCardsPool = _eventCardsPool.OrderBy(x => Random.value).ToArray();
    }
    public void AddToEventCardsPoolByKeyword(string keyword)
    {
        var cardsToAdd = _eventCards.Where(card => card.keyWords.Any(kw => kw.Equals(keyword))).ToArray();
        _eventCardsPool = _eventCardsPool.Concat(cardsToAdd).ToArray();
    }

    public void RemoveFromEventCardsPoolByQuest(string quest)
    {
        _eventCardsPool = _eventCardsPool.Where(card => !card.quest.Equals(quest)).ToArray();
    }
    public void GenerateCardPool(ICard[] cards)
    {

    }
}