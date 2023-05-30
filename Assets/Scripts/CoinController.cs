using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private float despawnDuration = 7f;
    private float despawnTimer;
    public int currencyValue = 10;
    private static bool gameFinished = false;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        despawnTimer = despawnDuration;
    }

    private void Update()
    {
        despawnTimer -= Time.deltaTime;
        if (despawnTimer <= 0f)
        {
            Destroy(gameObject);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (gameFinished)
                return;
            gameManager.UpdateCurrency(currencyValue);
            Destroy(gameObject);
        }
    }

    public void FinishGame()
    {
        gameFinished = true;
        CoinController[] coins = FindObjectsOfType<CoinController>();
        foreach (CoinController coin in coins)
        {
            Destroy(coin.gameObject);
        }
    }
}
