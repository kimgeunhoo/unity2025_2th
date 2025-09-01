using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [field:SerializeField] public int Value { get; private set; } = 5;

    private void Start()
    {
        Value += UnityEngine.Random.Range(0, 6);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // 동전을 획득했습니다. 이벤트를 실행

            // 이벤트가 발생했습니다.
            Bus<IGetCoinEvent>.Raise(new IGetCoinEvent(Value));
            Destroy(gameObject);

            // 이벤트 코드를 실행시키는 형태.
            // Bus<T>.Raise(new T());

            

        }
    }


}
