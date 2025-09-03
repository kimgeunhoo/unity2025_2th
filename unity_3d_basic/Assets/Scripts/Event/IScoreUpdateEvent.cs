using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IScoreUpdateEvent : IEvent
{
    public int Score;

    public IScoreUpdateEvent(int score)
    {
        Score = score;
    }
}
