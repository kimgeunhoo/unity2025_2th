using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    public int spawnCount = 1;


    public void OnEnable()
    {
        Bus<IGetCoinEvent>.OnEvent += HandleGetCoin;
    }

    public void OnDisable()
    {
        Bus<IGetCoinEvent>.OnEvent -= HandleGetCoin;
    }

    private void HandleGetCoin(IGetCoinEvent evt)
    {
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
