using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Stats : MonoBehaviour
{
    [SerializeField] private Entity_StatsData statData;
    public Entity_StatsData StatData { get; set; }

    public float GetMaxHealth()
    {
        float baseHP = statData.maxHealth.GetValue();
        float bonusHp = statData.Vitality.GetValue() * 5;

        return (baseHP + bonusHp);
    }

    private void Awake()
    {
        StatData = (Entity_StatsData)statData.Clone();
        StatData.Vitality.AddModifier(5, "Item");  // 아이템으로 인해 체력스탯이 5 상승
        StatData.Strength.AddModifier(3, "Item"); // 아이템으로 인해 힘스탯이 3 상승
    }


}
