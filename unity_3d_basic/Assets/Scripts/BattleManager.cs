using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Turn 
    int turnValue;

    public bool playerTurn = true;

    public void TurnChange()
    {
        playerTurn = !playerTurn;
        EnemyTurn();
    }

    private void EnemyTurn()
    {
        EnemyAI();
        playerTurn = true;
    }

    // Enemy 행동한다.

    public Battle Enemy;
   public void EnemyAI()
    {
        // 랜덤으로 0 ~ 2 숫자 받아온다
        int RandomValue = UnityEngine.Random.Range(0, 3);

        switch(RandomValue) 
        { 
            case 0:
                Debug.Log($"Enemy의 공격");
                //Enemy.Attack();
                break;
            case 1:
                Enemy.Recover(10);
                break;
            case 2:
                Enemy.ShieldUp(5);
                break;
        }
    }
}
