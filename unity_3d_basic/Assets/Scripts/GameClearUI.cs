using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearUI : MonoBehaviour
{
    [SerializeField] Button RestartButton;
    [SerializeField] Button QuitButton;

    private void OnEnable()
    {
        RestartButton.onClick.AddListener(Restart);
        QuitButton.onClick.AddListener(Quit);
    }

    private void OnDisable()
    {
        RestartButton.onClick.RemoveAllListeners();// RemoveListener() 단일 제거도 가능
        QuitButton.onClick.RemoveAllListeners(); // 
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        // 에디터에선 이 기능이 안먹힌다.
        Application.Quit();
        // application
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        // sceneManager
        SceneManager.LoadScene(0);
    }
}
