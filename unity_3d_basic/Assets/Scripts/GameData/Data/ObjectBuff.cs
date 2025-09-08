using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Buff
{
    public StatType type = StatType.UnDefined;
    public float Value = 5.0f;
}

public class ObjectBuff : MonoBehaviour
{
    Entity_Stats statsToMod;
    SpriteRenderer spriteRenderer;

    // Tag가 Player인 객체와 충돌했을 때 => OnT, OnC 택1

    [Header("Buff Detail")]
    [SerializeField] Buff[] buffs;
    [SerializeField] private float buffTime = 5.0f;
    [SerializeField] private string buffName;  

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // collision으로부터 Component를 Get해서 statsToMod에 저장
            statsToMod = collision.GetComponent<Entity_Stats>();
            // if Entity_stats가 있을 때만 넣기
            StartCoroutine(BuffCo());
            
        }
    }

    IEnumerator BuffCo()
    {
        spriteRenderer.color = Color.clear;

        foreach (Buff buff in buffs)
        {
            statsToMod.GetStatbyType(buff.type).AddModifier(buff.Value, buffName);
        }

        // 아이템으로 인해 체력스탯이 5 상승
        //Debug.Log($"플레이어의 현재 체력 스탯 : {statsToMod.StatData.Vitality.GetValue()}");
        Bus<IStatUpdateEvent>.Raise(new IStatUpdateEvent());

        // spriteRender 변수 추가 후 sr.color 안보이게 설정하는 코드 작성
        yield return new WaitForSeconds(buffTime);
        // ??초 Delay 후에 증가되었던 임시 스탯을 없애고 이 오브젝트를 파괴하라

        foreach (Buff buff in buffs)
        {
            statsToMod.GetStatbyType(buff.type).RemoveModifier(buffName);  // Item경로에서 얻은 스탯 제거
        }
        
        Bus<IStatUpdateEvent>.Raise(new IStatUpdateEvent());
        Destroy(gameObject);
    }

}
