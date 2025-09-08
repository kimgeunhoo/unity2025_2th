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
    }

    public Stat GetStatbyType(StatType type)
    {
        switch (type)
        {
            case StatType.Strength:
                return StatData.Strength;
            case StatType.Dexerity:
                return StatData.Dexerity;
            case StatType.Intelligence:
                return StatData.Intelligence;
            case StatType.Vitality:
                return statData.Vitality;
            case StatType.UnDefined:
                {
                    Debug.LogError("지정된 stattype이 존재하지 않습니다.");
                    return null; 
                }
            default:
                return null;
        }

    }
}