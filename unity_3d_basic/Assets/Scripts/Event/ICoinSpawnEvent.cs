using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 이벤트가 언제 실행되는가? Raise
// 이 이벤트가 실행되었을 때 무엇을 하는가? OnEvent 등록

public class ICoinSpawnEvent : IEvent
{
    public Coin Coin;


    public ICoinSpawnEvent(Coin coin)
    {
        Coin = coin;
    }

    
}
