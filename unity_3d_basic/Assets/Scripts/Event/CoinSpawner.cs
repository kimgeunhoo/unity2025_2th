using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. 동전 먹었을 때 작동

// 2. 동전이 생성이 되었으면 얼마만큼의 동전이 현재 게임 씬에 존재하는지 파악하는 코드를 작성해라.

public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    public int spawnCount = 1; // 한번에 생성할 동전의 갯수
    public List<Coin> spawnedList = new();
    public int SpawnedCount; // Scene에 생성된 코인의 수

    public void OnEnable()
    {
        Bus<IGetCoinEvent>.OnEvent += HandleGetCoin;
        Bus<ICoinSpawnEvent>.OnEvent += HandleSpawnCoin;
    }

   
    public void OnDisable()
    {
        Bus<IGetCoinEvent>.OnEvent -= HandleGetCoin;
        Bus<ICoinSpawnEvent>.OnEvent -= HandleSpawnCoin;
    }

    // ICoinSpawnEvent가 Coin 정보를 저장하도록 Coin 변수를 선언하기
    // Raise 함수를 실핼할 때 Coin 정보를 전달하도록 수정해보기
    private void HandleSpawnCoin(ICoinSpawnEvent evt)
    {
        // Coin 객체가 얼마 만큼 저장되어 있는가? 자료구조로 저장을 하겠다.
        spawnedList.Add(evt.Coin);
        SpawnedCount++;
    }

    private void HandleGetCoin(IGetCoinEvent evt)
    {
        // 코인 생성 SpawnCount

        // 획득한 코인은 리스트에서 제거
        spawnedList.Remove(evt.Coin);
        SpawnedCount--;
        // 동전이 생성된 갯수가 일정 이하일 때만 생성
        if (spawnCount > 2) { return; }

        for (int i = 0; i < spawnCount; i++)
        {
            Vector2 randomSpawnPos = UnityEngine.Random.insideUnitCircle * 10;
            Instantiate(CoinPrefab, transform.position + (Vector3)randomSpawnPos, Quaternion.identity);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(Vector3.zero, 10);

    }

}
