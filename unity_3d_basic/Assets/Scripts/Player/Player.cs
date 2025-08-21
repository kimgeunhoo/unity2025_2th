using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 기능을 구현하는것이 목표이다.
// 전투와 관련된 요소를 정의한다.

// 직렬화 (Serialized) : 우리가 직접 정의한 클래스 정보를 유니티에서 읽어올 수 없기 때문에 유니티 인스펙터에서 노출할 수 없다
// 유니티가 우리가 정의한 정보를 읽을 수 있도록 조치를 취한다.

/*
    abstract vs virtual

    abstract 가상 함수 : 본문을 가질 수 없다 - 자식 클래스에서 구현 강제
    virtual 가상 함수 : 본문을 가질 수 있다. 자식 클래스에서 이 코드를 사용을 안할 수도 있다.
    base 키워드를 사용 가능
 */

public class Player : Battle
{
    public override void Attack(Battle other)
    {
        if (!battleManager.playerTurn) return;

        other.TakeDamage(this);
        battleManager.TurnChange();
    }

    public override void Recover(int amount)
    {
        if (!battleManager.playerTurn) return;

        base.Recover(amount);
        battleManager.TurnChange();
    }

    public override void ShieldUp(int amount)
    {
        if (!battleManager.playerTurn) return;

        base.ShieldUp(amount);
        battleManager.TurnChange();
    }
}
