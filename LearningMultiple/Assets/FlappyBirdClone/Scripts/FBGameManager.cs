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
    [SerializeField]
    private GameObject gameOverUI = null;
    [SerializeField]
    private GameObject actualFinalScoreText = null;
    [SerializeField]
    private float showGameOverAnimationTime = 1.4f;
    [SerializeField]
    private float scoreTimer = 1.5f;

    private TextMeshProUGUI scoreTmp;
    private TextMeshProUGUI actualFinalScoreTmp;

    public static bool IsRunning => gameState == GameState.Running;

    private void Awake()
    {
        scoreTmp = scoreText.GetComponent<TextMeshProUGUI>();
        actualFinalScoreTmp = actualFinalScoreText.GetComponent<TextMeshProUGUI>();

        score = 0;
        gameState = GameState.Running;
        gameOverUI.SetActive(false);
    }

    private void Update()
    {
        if (gameState == GameState.Running)
        {
            scoreTmp.text = score.ToString();
        }
        else if (gameState == GameState.Ending)
        {
            scoreTmp.text = "";
            gameState = GameState.Stopped;

            StartCoroutine(ShowGameOver());
        }
    }

    private IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(1f);

        gameOverUI.SetActive(true);

        yield return new WaitForSeconds(showGameOverAnimationTime);

        float timeEachIncrement = scoreTimer / score;
        
        int finalScoreCounter = 0;
        while (finalScoreCounter < score)
        {
            finalScoreCounter++;
            finalScoreCounter = finalScoreCounter >= score 
                    ? score 
                    : finalScoreCounter;

            actualFinalScoreTmp.text = finalScoreCounter.ToString();

            yield return new WaitForSeconds(timeEachIncrement);
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Debug.Log("Return to game selection");
    }
}

public enum GameState
{
    Running, Ending, Stopped
}