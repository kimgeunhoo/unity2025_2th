using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEventUI : MonoBehaviour
{
    [Header("NPC UI")]
    public GameObject NPCPanel;
    public GameObject StorePanel;
    public Image NpcSprite;
    public TextMeshProUGUI NpcName;
    public TextMeshProUGUI NpcDialogue;

    private void OnEnable()
    {
        Bus<ICollisionWithPlayerEvent>.OnEvent += HandleNPCUI;
    }

    private void OnDisable()
    {
        Bus<ICollisionWithPlayerEvent>.OnEvent -= HandleNPCUI;
    }

    private void Start()
    {
        NPCPanel.SetActive(false);
        StorePanel.SetActive(false);
    }

    private void HandleNPCUI(ICollisionWithPlayerEvent evt)
    {
        NPCPanel.SetActive(true);

        NpcSprite.sprite = (evt.npc.npcInfo.Sprite);
        NpcName.SetText(evt.npc.npcInfo.NpcName);
        NpcDialogue.SetText(evt.npc.npcInfo.NPCDialogue);

        
    }
}
