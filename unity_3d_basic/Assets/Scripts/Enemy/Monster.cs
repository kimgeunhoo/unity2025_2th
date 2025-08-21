using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 부모의 함수를 가져와서 사용하는 방법을 학습.
// 부모의 함수를 다시 정의한다 (재정의) override

public class Monster : Battle
{
    public override void Attack(Battle other)
    {
        if (battleManager.playerTurn) return;

        // Battle컴포넌트를 가진 상대가 TakeDamage(this.BattleEntity);

        other.TakeDamage(this);
    }

    //public override void Attack()
    //{
    //    // battleManager에서 player턴이면 실행 하지 마시오
    //    if (battleManager.playerTurn) return;

    //    //base.Attack(); // 몬스터의 공격 로직을 실행 후,

    //    Debug.Log("Monster Attack!");
    //    // battleManager에서 턴을 종료한다. - 몬스터는 할 필요가 없다.
    //}

    public override void Recover(int amount)
    {
        if (battleManager.playerTurn) return;

        base.Recover(amount);
    }

    public override void ShieldUp(int amount)
    {
        if (battleManager.playerTurn) return;

        base.ShieldUp(amount);
    }

}
