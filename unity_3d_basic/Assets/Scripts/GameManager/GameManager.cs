using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    public void GameClear()
    {
        if(IsGameClear())
        {
            //Bus<I~~Event>.Raise(new ~~())
            Bus<IGameClearEvnet>.Raise(new IGameClearEvnet());
        }
    }
    public bool IsGameClear()
    {
        //if () // 게임 클리어를 위한 조건 필요 시, if문 작성
        //{
        //    return false;
        //}
        return true;
    }

    public void GameOver() 
    {
        // 게임 오버되었다 메시지 출력
        // Bus<I~~Event>.Raise(new ~~())
        Bus<IGameOverEvent>.Raise(new IGameOverEvent());
    }
}
