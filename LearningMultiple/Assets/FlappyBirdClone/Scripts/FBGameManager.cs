using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FBGameManager : MonoBehaviour
{
    public static GameState gameState;
    public static int score;

    [SerializeField]
    private GameObject scoreText = null;

    private TextMeshProUGUI scoreTmp;

    public static bool IsRunning => gameState == GameState.Running;

    private void Awake()
    {
        scoreTmp = scoreText.GetComponent<TextMeshProUGUI>();

        score = 0;
        gameState = GameState.Running;
    }

    private void Update()
    {
        scoreTmp.text = score.ToString();
    }

    public static void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

public enum GameState
{
    Running, Stopped
}