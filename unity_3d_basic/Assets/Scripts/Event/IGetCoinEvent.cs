using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGetCoinEvent : IEvent
{
    public int Value;

    public IGetCoinEvent(int value)
    {
        Value = value;
    }
}
