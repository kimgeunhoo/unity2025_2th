using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity_Stats", menuName = "Custom/Stat System/Entity_Stats")]
public class Entity_StatsData : ScriptableObject, ICloneable
{
    public Stat maxHealth;
    public Stat Strength;
    public Stat Dexerity;
    public Stat Intelligence;
    public Stat Vitality;

    public object Clone()
    {
        return Instantiate(this);
    }
}
