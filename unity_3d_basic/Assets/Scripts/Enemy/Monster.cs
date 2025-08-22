using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 부모의 함수를 가져와서 사용하는 방법을 학습.
// 부모의 함수를 다시 정의한다 (재정의) override

namespace BattleEample
{
    public class Monster : Battle
    {
        [SerializeField] Animator animator;

        public override void Attack(Battle other)
        {
            if (battleManager.playerTurn) return;

            // Battle컴포넌트를 가진 상대가 TakeDamage(this.BattleEntity);

            other.TakeDamage(this);

            animator.SetTrigger("Monster Attack");  // 공격 애니메이션 실행
            other.TakeDamage(this);                 // 데미지 로직 실행
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

        public override void AttackSkill(Battle other)
        {
            if (battleManager.playerTurn) return;

            Debug.Log("Enemy using Attack Skill!");
            other.useMana(this);
            other.TakeDamage(this);
            battleManager.TurnChange();
        }

        public override void MagicSkill(Battle other, int amount)
        {
            if (battleManager.playerTurn) return;
            Debug.Log("Enemy using Magic Skill!");
            other.useMana(this);
            base.Recover(amount);
            battleManager.TurnChange();
        }

        public override void DefenseSkill(Battle other, int amount)
        {
            if (battleManager.playerTurn) return;
            Debug.Log("Player using Magic Skill!");
            other.useMana(this);
            base.ShieldUp(amount);
            battleManager.TurnChange();
        }
    }

}