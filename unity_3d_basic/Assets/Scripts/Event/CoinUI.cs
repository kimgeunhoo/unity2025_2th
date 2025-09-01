using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;

    private int currentCoin;

    // 코인이 변경되었을 떄만 실행한다

    private void OnEnable()
    {
        // 
        Bus<IGetCoinEvent>.OnEvent += HandleGetCoin;
      
    }

    private void OnDisable()
    {
        Bus<IGetCoinEvent>.OnEvent -= HandleGetCoin;
    }

    private void Start()
    {
        currentCoin = 0; // 플레이어의 동전 정보;
        Bus<IGetCoinEvent>.Raise(new IGetCoinEvent(0));
    }

    private void HandleGetCoin(IGetCoinEvent evt)
    {
        currentCoin += evt.Value;
        coinText.SetText($"Current Coin : {currentCoin}");
    }

}
