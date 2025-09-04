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

    [Header("GameOverUI")]
    public GameObject GameOverPanel;

    [Header("GameClearUI")]
    public GameObject GameClearPanel;

    private void Start()
    {
        // 유니티 씬에서 실수로 활성화해둔 상태여도, 코드로 비활성화 가능
        NPCPanel.SetActive(false);
        StorePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GameClearPanel.SetActive(false);   
    }

    private void OnEnable()
    {
        Bus<ICollisionWithPlayerEvent>.OnEvent += HandleNPCUI;
        Bus<IGameOverEvent>.OnEvent += HandleGameOver;
        Bus<IGameClearEvnet>.OnEvent += HandleGameClear;
    }
  
    private void OnDisable()
    {
        Bus<ICollisionWithPlayerEvent>.OnEvent -= HandleNPCUI;
        Bus<IGameOverEvent>.OnEvent -= HandleGameOver;
        Bus<IGameClearEvnet>.OnEvent -= HandleGameClear;
    }



    private void HandleGameOver(IGameOverEvent evt) // 처치한 대상에 따라서 GameOver 내용이 바뀌는 UI 존재
    {
        Time.timeScale = 0f; // 재시작시 TimeScale을 1로 다시 되돌려야한다.
        GameOverPanel.SetActive(true);
    }

    private void HandleGameClear(IGameClearEvnet evt)
    {
        Time.timeScale = 0f; // 재시작시 TimeScale을 1로 다시 되돌려야한다.
        GameClearPanel.SetActive(true);
    }

    private void HandleNPCUI(ICollisionWithPlayerEvent evt)
    {
        NPCPanel.SetActive(true);

        NpcSprite.sprite = (evt.npc.npcInfo.Sprite);
        NpcName.SetText(evt.npc.npcInfo.NpcName);
        NpcDialogue.SetText(evt.npc.npcInfo.NPCDialogue);   
    }


}
