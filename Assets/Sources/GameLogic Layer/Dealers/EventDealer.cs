using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardSystem;
using System;

public class EventDealer : MonoBehaviour
{
    public static EventDealer instance;
    [SerializeField] private EventCardData[] _eventCards;
    [Space(2f)]
    [SerializeField] private EventCardData[] _eventCardsPool;

    [SerializeField] private KeyWord[] _keyWords;
    [SerializeField] private Quest[] _quests;

    public EventCardData[] eventCards => _eventCards;
    public EventCardData[] eventCardsPool => _eventCardsPool;
    public KeyWord[] keyWords => _keyWords;
    public Quest[] quests => _quests;


    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        Debug.Log(StaticData.EventCardsCount);
    }

    public void GenerateCardPool(ICard[] cards)
    {

    }
}