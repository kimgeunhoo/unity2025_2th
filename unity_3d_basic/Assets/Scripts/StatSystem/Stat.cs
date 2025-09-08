using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private float baseValue;
    [SerializeField] private List<StatModifier> modifiers; // 아이템 장착 여부, 버프 유무, 레벨 증가
    public float GetValue()
    {
        return GetFinalValue();
    }

    public void AddModifier(float value, string source)
    {
        StatModifier modToAdd = new StatModifier(value, source);


        modifiers.Add(modToAdd);
    }

    public void RemoveModifier(string source) // buff, equip unequip
    {
        modifiers.RemoveAll(mode => mode.source == source);
    }

    private float GetFinalValue()
    {
        float finalValue = baseValue;

        // 아이템, 버프, 레벨업

        foreach(var mod in modifiers)
        {
            finalValue += mod.value;
        }

        return finalValue;
    }
}

[System.Serializable]
public class StatModifier
{
    public float value;
    public string source; // 아이템, 버프, 레벨업 수치

    public StatModifier(float value, string source)
    {
        this.value = value;
        this.source = source;
    }
}
