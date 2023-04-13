using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeSystem : MonoBehaviour
{
    public static SwipeSystem instance;
    private void Awake()
    {
        instance = this;
    }

}
