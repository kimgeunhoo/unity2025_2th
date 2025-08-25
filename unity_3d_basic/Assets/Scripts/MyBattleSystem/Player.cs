using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Battle
{
    // 충돌 체크를 위한 변수
    [SerializeField] AttackChecker attackChecker;

    // 1. 왜 변수를 추가해야 하는가?
    // 2. 변수에 데이터를 초기화할 것인가? <1> 유니티 인스펙터 <2> 코드 사용
    [SerializeField] Animator animator;

    private void Start()
    {
        attackChecker = GetComponentInChildren<AttackChecker>();
    }
    public override void Attack(Battle other)
    {
        if (!battleManager.playerTurn) return;

        attackChecker.gameObject.SetActive(true);   
        animator.SetTrigger("Player Attack");
        other.TakeDamage(this);
        battleManager.TurnChange();
    }

    //public override void Attack()
    //{
    //    base.Attack();

    //    attackChecker.gameObject.SetActive(false);

    //    // 공격 하면서 애니메이션을 실행시키겠다.
    //    animator.SetTrigger("Player Attack");
    //    // 공격을 아면서 UI Text 출력시키겟다
        
    //    // 충돌 이벤트 구현

    //    // 일정 시간 후에 활성화된 공격이 비활성화된다 

    //}

    public override void ShieldUp(int amount)
    {
        if (!battleManager.playerTurn) return;

        base.ShieldUp(amount);
        animator.SetTrigger("Player ShieldUp");
        battleManager.TurnChange();
    }

    public override void Recover(int amount)
    {
        if (!battleManager.playerTurn) return;

        base.Recover(amount);
        animator.SetTrigger("Player Recover");
        battleManager.TurnChange();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
    }
    public override void TakeDamage(Battle other)
    {
        base.TakeDamage(other);

        animator.SetTrigger("Hit");
    }


    // 스킬코드
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