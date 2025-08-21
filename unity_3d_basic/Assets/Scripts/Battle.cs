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
    public int MANA;
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
    public BattleEntity(int hP, int aTK, int dEF, int mANA)
    {
        HP = hP;
        ATK = aTK;
        DEF = dEF;
        MANA = mANA;
    }
}

[System.Serializable]
public class BattleUI
{
    public Image HpBar;
    public Image ManaBar;
    public TextMeshProUGUI BattleEntityText;

    public void SetBattleUI(BattleEntity battleEntity)
    {
        BattleEntityText.SetText($"HP : {battleEntity.HP}, ATK : {battleEntity.ATK}, DEF : {battleEntity.DEF}, Mana : {battleEntity.MANA}");
    }

    public void SetSkillUI(BattleEntity battleEntity)
    {

    }

    public void SetHPBar(int current, int max)
    {
        HpBar.fillAmount = (float)current / max;
    }

    public void SetManaBar(int current, int max) 
    {
        ManaBar.fillAmount = (float)current / max;    
    }

}

// 추상 클래스.
// 이 클래스를 인스턴스 할 수 없다.
// 이 클래스를 오브젝트의 컴포넌트로 사용하지 마시오.
// Player, Monster를 사용해서 이 클래스를 구현하라.
// 메소드에 abstrct 키워드 추가할 수 있다.


public abstract class Battle : MonoBehaviour
{
    public BattleEntity battleEntity;
    public BattleUI battleUI;
    public BattleManager battleManager;

    public int Mana { 
        get
        {
            if (currentMana <= 0)
            {
                
            }
            else
            {

            }
            return currentMana;
        }
        private set
        {

        }
    }
    

    public int CurrentHP {
        get {
            if (currentHP <= 0) // 남은 체력이 0보다 작거나 같을 때
            {
                // 사망 시의 효과음, 이펙트, 애니메이션 .... 이벤트 실행
                currentHP = 0;
                Death();
            }
            else  // 남은 체력이 0보다 클 때
            {
                // 피격 시의 효과음, 이펙트, 애니메이션 .... 이벤트 실행
            }
            return currentHP;
        }
        private set
        {
            if (value > battleEntity.HP) { value = battleEntity.HP; }

            currentHP = value;
        }
    } // Battle 클래스에서 현재 체력 변수를 수정 할수 있다.

    [SerializeField] private int currentHP;
    [SerializeField] private int currentMana;

    // Start is called before the first frame update
    void Start()
    {
        // battleEntity = new BattleEntity(playerHP, playerATK, playerDEF);

        Debug.Log($"HP : {battleEntity.HP}, ATK : {battleEntity.ATK}, DEF : {battleEntity.DEF}, Mana : {battleEntity.MANA}");
        battleUI.SetBattleUI(battleEntity);
        CurrentHP = battleEntity.HP;
        
    }

    // Update is called once per frame
    void Update()
    {
        battleUI.SetHPBar(CurrentHP, battleEntity.HP);
    }

    // 상대에게 데미지를 준다 (TakeDamage) :: CurrentHP - (ATK 방어력에 따라서 감소)

    public void TakeDamage(Battle other)
    {

        int FinalDamage = (other.battleEntity.ATK - battleEntity.DEF);
        if (FinalDamage <= 0) { FinalDamage = 1; }
        CurrentHP -= FinalDamage;  // 상대의 공격력   

        Debug.Log($"최종 데미지 : {FinalDamage}, 공격자의 공격력 : {other.battleEntity.ATK}, 방어력 : {battleEntity.DEF}");
    }

    // 죽었을 때 로직 처리하기 Die, Death :: CurrentHP 0보다 작아졌을 때 이벤트 실행

    public void Death()
    {
        // 사망 이벤트 호출
        Debug.Log($"사망했습니다, 현재 체력 : {currentHP}");
    }
    public abstract void Attack(Battle other);

    public virtual void Recover(int amount)
    {
        CurrentHP += amount;
    }

    public virtual void ShieldUp(int amount)
    {
        battleEntity.DEF += amount;
        battleUI.SetBattleUI(battleEntity);
    }
    
    public void UseSkill(int amount)
    {
        battleUI.SetBattleUI(battleEntity);
    }
}
