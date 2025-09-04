using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGameClearEvnet : IEvent
{
    public IGameClearEvnet GameClear;

    public IGameClearEvnet(IGameClearEvnet gameClear)
    {
        GameClear = gameClear;
    }
    public IGameClearEvnet()
    {

    }

}
