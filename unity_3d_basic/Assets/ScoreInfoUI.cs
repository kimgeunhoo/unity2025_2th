using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    private int currentScore;


    private void OnEnable()
    {
        Bus<IScoreUpdateEvent>.OnEvent += HandleScoreUIUpdate;
    }

    private void OnDisable()
    {
        Bus<IScoreUpdateEvent>.OnEvent -= HandleScoreUIUpdate;
    }

    private void HandleScoreUIUpdate(IScoreUpdateEvent evt)
    {
        currentScore += evt.Score;
        scoreText.SetText($"Score : {currentScore}");

        if (currentScore >= ScoreManager.Instance.BestScore)
        {
            bestScoreText.SetText($"BestScore : {currentScore}");
        }

    }

    public void SetScoreInfo()
    {
        currentScore = ScoreManager.Instance.Score;
        scoreText.SetText($"Score : {ScoreManager.Instance.Score}");
        ScoreManager.Instance.LoadScore();
        bestScoreText.SetText($"BestScore : {ScoreManager.Instance.BestScore}");
    }

    private void Start()
    {
        SetScoreInfo();
    }

    public void SaveBestScore()
    {
        ScoreManager.Instance.SaveScore(currentScore);
    }

    // 개선 필요 Bus<IScoreUpdateEvent>
    private void Update()
    {
       // SetScoreInfo();
       if(Input.GetKeyDown(KeyCode.U))
       {
            Debug.Log("현재 점수를 저장합니다.");
            Debug.Log(Application.persistentDataPath);
            SaveBestScore();
       }

    }



}
