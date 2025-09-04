using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGameOverEvent : IEvent
{
    public IGameOverEvent GameOver;

    public IGameOverEvent()
    {
    }

    public IGameOverEvent(IGameOverEvent gameOver)
    {
        GameOver = gameOver;
    }
}
