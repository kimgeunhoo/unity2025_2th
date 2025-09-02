using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 주위를 돌아다니는 기능 가진 AI
// 최소 속도, 최대 속도 변수 정의
// sprite
// 이름
[CreateAssetMenu(fileName = "Default NPC Name", menuName = "ScriptableObject/NPCData", order = 101)]
public class NPCInfo : ScriptableObject
{
    public int MinSpeed;
    public int MaxSpeed;
    public int PatrolRadius;
    public float stopDistance = 0.1f;
    public float patrolDistance = 5f;
    public Sprite Sprite;
    public string NpcName;

    public string NPCDialogue;
}
