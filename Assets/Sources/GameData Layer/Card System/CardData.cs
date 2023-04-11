using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Cards/CardData", order = 1)]
public class CardData : ScriptableObject
{
    public string title;
    [TextArea]
    public string description;
    public Sprite portrait;
    public Sprite background;


    [SerializeField] private CardEvent[] _cardEvents = new CardEvent[4];



}