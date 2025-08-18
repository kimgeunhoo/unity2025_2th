using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BattleEntity
{
    public int HP;
    public int ATK;
    public int DEF;
    public string AttackType;


    public BattleEntity() { }

    public BattleEntity(int hP, int aTK)
    {
        HP = hP;
        ATK = aTK;
    }

    public BattleEntity(int hP, int aTK, int dEF)
    {
        HP = hP;
        ATK = aTK;
        DEF = dEF;
    }
}

[System.Serializable]
public class BattleUI
{
    public Image HpBar;
    public TextMeshProUGUI BattleEntityText;

    public void SetBattleUI(BattleEntity battleEntity)
    {
        BattleEntityText.SetText($"HP : {battleEntity.HP}, ATK : {battleEntity.ATK}, DEF : {battleEntity.DEF}");
    }

    public void SetHPBar(int current, int max)
    {
        HpBar.fillAmount = (float)current / max;
    }

}

public class Battle : MonoBehaviour
{
    public BattleEntity battleEntity;
    public BattleUI battleUI;

    public int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        // battleEntity = new BattleEntity(playerHP, playerATK, playerDEF);

        Debug.Log($"HP : {battleEntity.HP}, ATK : {battleEntity.ATK}, DEF : {battleEntity.DEF}");
        battleUI.SetBattleUI(battleEntity);
        currentHP = battleEntity.HP;
    }

    // Update is called once per frame
    void Update()
    {
        battleUI.SetHPBar(currentHP, battleEntity.HP);
    }

    // 상대에게 데미지를 준다 (TakeDamage) :: CurrentHP - (ATK 방어력에 따라서 감소)

    // 죽었을 때 로직 처리하기 Die, Death :: CurrentHP 0보다 작아졌을 때 이벤트 실행

}
