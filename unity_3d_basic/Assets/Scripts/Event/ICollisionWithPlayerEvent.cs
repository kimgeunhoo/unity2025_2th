using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ICollisionWithPlayerEvent : IEvent
{
    public NPC npc;

    public ICollisionWithPlayerEvent(NPC npc)
    {
        this.npc = npc;
    }
}

/*  
    NPC 클래스
    제일 아래에 NPC와 충돌하는 코드
    플레이어와 발생하는 이벤트 생성
    (Raise)
    UI - NPC Player 충돌, Image Panel 활성화가 되고 Text로 대화한다.
    NPC 충돌 이후에 NPC가 게임에서 사라지게 할 수 있다.
    NPC 일정 수가 이하일 때 생성되도록 만들 수 있다.
*/
