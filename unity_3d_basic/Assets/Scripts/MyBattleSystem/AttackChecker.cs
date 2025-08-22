using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackChecker : MonoBehaviour
{
    public Battle owner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision 오브젝트 안에 공격이 가능한 컴포넌트 존재 시 - if 조건
        if(collision.TryGetComponent<Battle>(out Battle battle))
        {
            owner.Attack(battle);
        }
        // 공격하라 - battle 컴포넌트에 있는 공격 (공격 대상 : Battle 클래스)
    }
}
