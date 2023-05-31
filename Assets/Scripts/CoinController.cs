using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CoinController : MonoBehaviour, IPointerDownHandler
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
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameManager.UpdateCurrency(currencyValue);
        Destroy(gameObject);
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