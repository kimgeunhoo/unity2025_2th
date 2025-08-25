using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyObject : MonoBehaviour
{
    // Ready 스트립트가 Start 텍스트 작성이 되면 Square 오브젝트의 색깔을 기존 색과 다른 색으로 변경
    // Start 함수를 코루틴으로 변경해서 구현
    [SerializeField] private SpriteRenderer sr, sr2, sr3;

    // void Start -> IEnumerator Start 변경
    IEnumerator Start()
    {
        yield return new WaitForSeconds(6f);
        sr.color = Color.red;
        sr2.color = Color.red;
        sr3.color = Color.red;
    }

}
