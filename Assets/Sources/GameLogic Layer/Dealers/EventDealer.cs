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

    
    [SerializeField] private EventCardData[] _eventCards;
    [Space(2f)]
    [SerializeField] private EventCardData[] _eventCardsPool;

    [SerializeField] private KeyWord[] _keyWords;
    [SerializeField] private Quest[] _quests;

    public EventCardData[] eventCards => _eventCards;
    public EventCardData[] eventCardsPool => _eventCardsPool;
    public KeyWord[] keyWords => _keyWords;
    public Quest[] quests => _quests;
    public UISwipeableViewBasic SwipeableView => instance._swipeableView;


    private void Awake()
    {
        instance = this;
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

    public void GenerateCardPool(ICard[] cards)
    {

    }
}