using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Health : MonoBehaviour
{
    private Entity_Stats stats;

    [SerializeField] protected float currentHP;

    private void Start()
    {
        stats = GetComponent<Entity_Stats>();

        currentHP = stats.GetMaxHealth();
    }
}
