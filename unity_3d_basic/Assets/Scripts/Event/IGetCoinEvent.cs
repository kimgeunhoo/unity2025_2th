using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGetCoinEvent : IEvent
{
    public Coin Coin;

    public IGetCoinEvent(Coin coin)
    {
        Coin = coin;
    }

    public IGetCoinEvent()
    {

    }
}
