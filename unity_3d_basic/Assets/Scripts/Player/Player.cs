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

namespace BattleEample
{
    
    public class Player : Battle
    {
        [SerializeField] Animator animator; 
        Player player;
        public override void Attack(Battle other)
        {
            if (!battleManager.playerTurn) return;

            animator.SetTrigger("Player Attack"); 
            other.TakeDamage(this);
            battleManager.TurnChange();
        }

        // SetTrigger 실행할 때 애니메이션 파라미터 이름과 동일하지 않으면 에러 발생

        public override void Recover(int amount)
        {
            if (!battleManager.playerTurn) return;

            base.Recover(amount);
            animator.SetTrigger("Player Recover");
            battleManager.TurnChange();
        }

        public override void ShieldUp(int amount)
        {
            if (!battleManager.playerTurn) return;

            base.ShieldUp(amount);
            animator.SetTrigger("Player ShieldUp");
            battleManager.TurnChange();
        }


        // 추가코드
        public override void AttackSkill(Battle other)
        {
            if (!battleManager.playerTurn) return;

            Debug.Log("Player using Attack Skill!");
            useMana(this); // 마나 사용
                           // TakeDamage 외의 다른 스킬 매커니즘 적용가능
            other.HeadStrike(this);
            battleManager.TurnChange();
        }

        public override void MagicSkill(Battle other, int amount)
        {
            if (!battleManager.playerTurn) return;
            Debug.Log("Player using Magic Skill!");


            base.InhancedHeal(amount);
            battleManager.TurnChange();
        }

        public override void DefenseSkill(Battle other, int amount)
        {
            if (!battleManager.playerTurn) return;
            Debug.Log("Player using Magic Skill!");

            base.IronGuard(amount);
            battleManager.TurnChange();
        }
    }

}