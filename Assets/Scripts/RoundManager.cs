using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundManager : MonoBehaviour
{
    public List<GameObject> enemySpawnerObjects; // List of EnemySpawner objects

    public float roundDuration = 30f; // Duration of each round in seconds
    public TMP_Text timerText;

    private float roundTimer;
    private bool roundActive = false;
    private GameManager gameManager;

    private List<EnemySpawner> enemySpawners = new List<EnemySpawner>();

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ResetTimer();
        for (int i = 0; i < enemySpawnerObjects.Count; i++)
        {
            EnemySpawner enemySpawner = enemySpawnerObjects[i].GetComponent<EnemySpawner>();
            if (enemySpawner != null)
            {
                enemySpawners.Add(enemySpawner);
            }
        }
        StartRound();
    }

    private void Update()
    {
        if (roundActive)
        {
            roundTimer -= Time.deltaTime;

            if (roundTimer <= 0f)
            {
                roundTimer = 0f;
                EndRound();
                gameManager.RoundOver();
            }

            UpdateTimerDisplay();
        }
    }

    public void StartRound()
    {
        roundActive = true;
        // Enable and start spawning for each EnemySpawner script
        for (int i = 0; i < enemySpawnerObjects.Count; i++)
        {
            EnemySpawner[] enemySpawnerScripts = enemySpawnerObjects[i].GetComponents<EnemySpawner>();
            for (int j = 0; j < enemySpawnerScripts.Length; j++)
            {
                enemySpawnerScripts[j].enabled = true;
                enemySpawnerScripts[j].StartSpawning();
            }
        }
    }

    public void EndRound()
    {
        for (int i = 0; i < enemySpawnerObjects.Count; i++)
        {
            EnemySpawner[] enemySpawnerScripts = enemySpawnerObjects[i].GetComponents<EnemySpawner>();
            for (int j = 0; j < enemySpawnerScripts.Length; j++)
            {
                enemySpawnerScripts[j].enabled = false;
                enemySpawnerScripts[j].StopSpawning();
            }
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(roundTimer / 60);
        int seconds = Mathf.FloorToInt(roundTimer % 60);

        timerText.text = minutes.ToString() + ":" + seconds.ToString("D2");
    }

    private void ResetTimer()
    {
        roundTimer = roundDuration;
        UpdateTimerDisplay();
    }

    public float GetRoundTimer()
    {
        return roundTimer;
    }
}
