using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatUIContainer : MonoBehaviour
{
    [SerializeField] Entity_Stats playerStat;

    public StatUIElement[] stats;

    public void Start()
    {
        // STR - 0, Dex - 1, INT - 2, VIT - 3
        StatUpdate();
    }

    private void OnEnable()
    {
        Bus<IStatUpdateEvent>.OnEvent += OnStatUpdate;
    }

    private void OnDisable()
    {
        Bus<IStatUpdateEvent>.OnEvent -= OnStatUpdate;
    }

    private void OnStatUpdate(IStatUpdateEvent evt)
    {
        StatUpdate();
    }

    private void StatUpdate()
    {
        stats[0].SetUI(playerStat.StatData.Strength.GetValue());
        stats[1].SetUI(playerStat.StatData.Dexerity.GetValue());
        stats[2].SetUI(playerStat.StatData.Intelligence.GetValue());
        stats[3].SetUI(playerStat.StatData.Vitality.GetValue());
    }

    // Raise 
}
