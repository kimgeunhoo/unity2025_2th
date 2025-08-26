using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    // 2d 월드에서 랜덤한 위치로 이동하는 코드 작성
    // 이동 속도는 얼마인가
    // 이동 하는 방식은 ㅡ무엇인가? rigidbody2d 이용한 방식
    // 서로 충돌했을 때는 어떤 일이?

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private Vector2 targetVector;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();    
        targetVector = SetPositionToCenter();
    }

    // Update is called once per frame
    void Update()
    {
        SetPositionToCenter();
        targetVector = SetPositionToCenter();

        _rigidbody2D.velocity = targetVector.normalized * moveSpeed;
    }

    public Vector2 SetPositionToCenter() 
    {
       return Vector2.zero - (Vector2)transform.position;
    }
}
