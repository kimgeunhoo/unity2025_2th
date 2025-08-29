using System.Collections;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : MonoBehaviour
{
    [SerializeField] NPCInfo npcInfo;

    // 클래스가 부착되어 있는 오브젝트의 다른 컴포넌트를 참조해서 사용할 수 있다.
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;

    
    [SerializeField] private Vector2 currentTargetPos; // 언제 Stop을 해야하는가
    [SerializeField] private bool IsMoving; // 목적지 도착 후에 한번만 위치를 재설정하기 위함

    [SerializeField] Transform playerPos;
    // 정찰, 추적 기능


    private void Awake()
    {
        // NPC 클래스와 같은 오브젝트에 부착되어 있는 컴포넌트를 GetCOmponent로 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        // 컴포넌트에 데이터를 연결했으면 실제 데이터로 설정해주시오

        spriteRenderer.sprite = npcInfo.Sprite;
        rigidbody2D.gravityScale = 0;

    }
    private void Start()
    {
        SetRandomPosition();
    }

    private void Update()
    {
        // 언제 정찰? 현재 플레이어와의 거리에 따라서 정찰할 지 추적할 지 정한다.
        // test1 대신 Vector2.Distance 함수 사용해서 코드 활용
        //Vector2.Distance(playerPos.transform.position, currentTargetPos) < 10
        if (IsPatrol())
        {
            Patrol();
        } else
        {
            Chase();
        }

        // else if(공격최소거리)
        //{
        //    Attack();
        //}
        // Enemy attack, 공격하기 위한 최소 거리

        // 언제 추적?
    }

    // 현재 상태를 체크해주는 함수
    bool IsPatrol()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < npcInfo.patrolDistance)
        {
            return false;
        }
        else if(Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < npcInfo.patrolDistance - 3)
        {
            return false;
            // 사거리 조절해서 특정 사거리 시 공격 구현
        }
        else
        {
            return true;
        }


    }

    public void Patrol()
    {
        // 이동해라 MoveTargetPoint
        MoveTargetPoint();
    }

    public void Chase()
    {
        // Player를 어떻게 받아올 것인가? 게임오브젝트 이름이 player, tag가 player인 오브젝트를 전달해준다.
      
        SetPosition(playerPos.position);
        MoveTargetPoint();
    }

    private void MoveTargetPoint()
    {
        // 속도의 랜덤값 구현
        float moveSpeed = Random.Range((float)npcInfo.MinSpeed, npcInfo.MaxSpeed);

        // 이동 속도, 이동해야 할 위치, 현재 위치 (이동해야할 방향)
        // 두 벡터 위치 값과 속도를 사용해서 => 코드를 구현하기. 이동해야할 방향 * 속도

        // 목적지까지 도착했으면 멈춰라
        // Vector Distance
        if (Vector2.Distance(transform.position, currentTargetPos) < npcInfo.stopDistance) // 대상과의 멈추기 위한 거리 stopDistance
        {
            rigidbody2D.velocity = Vector2.zero;
            IsMoving = true;
            // 잠시 대기하는 시간 필요
            // 이벤트 처리, StopEvent

            // SetRandomPosition 실행
            //if(IsMoving)
            //{
            //    StartCoroutine(SetRandomPositionCoroutine());
            //}       
            //Invoke(nameof(SetRandomPosition), 1f); // 단순하게 사용시 쓰면 좋다

            if (IsPatrol())
            { 
                SetRandomPosition();
            }
        }
        else
        {
            // 그렇지 않으면 이동하라
            rigidbody2D.velocity = (currentTargetPos - (Vector2)transform.position).normalized * moveSpeed;
        }     
    }

    private void SetRandomPosition()
    {
        // 위치의 랜덤값 표현
        currentTargetPos = (Vector2)transform.position + Random.insideUnitCircle * npcInfo.PatrolRadius;

    }

    public void SetPosition(Vector2 position)
    {
        currentTargetPos = position;
    }

    private IEnumerator SetRandomPositionCoroutine()
    {
        IsMoving = false;
        yield return new WaitForSeconds(1f);
        SetRandomPosition();
    }

    private void OnDrawGizmos()
    {
        //DrawChaseCircle();
    }

    // 기즈모를 그리는 특수한 함수
    private void OnDrawGizmosSelected()
    {
        DrawChaseCircle();    
    }

    private void DrawChaseCircle()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, npcInfo.patrolDistance);

    }

}
