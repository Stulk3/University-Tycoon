using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{
    public static int EventCardsCount = 0;


    public static void AddCardToEventDataCount()
    {
        EventCardsCount++;
    }
    public static void DeleteCardFromEventDataCount()
    {
        EventCardsCount--;
    }
}
