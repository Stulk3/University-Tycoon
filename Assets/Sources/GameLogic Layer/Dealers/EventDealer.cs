using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardSystem;
using SwipeableView;
using System.Linq;

public class EventDealer : MonoBehaviour
{
    public static EventDealer instance;

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
    private void Update()
    {
        Debug.Log(StaticData.EventCardsCount);
    }
    private void Start()
    {
        var data = Enumerable.Range(0, 20)
        .Select(i => new BasicCardData
        {
            color = new Color(Random.value, Random.value, Random.value, 1.0f)
        })
        .ToList();

        _swipeableView.UpdateData(data);
    }

    public static void SwapOrFillArray(UISwipeableCardBasic card)
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
    public void GenerateCardPool(ICard[] cards)
    {

    }
}