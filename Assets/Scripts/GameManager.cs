using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject draggingUnit;
    public GameObject currentContainer;
    public GameObject gameUnit;
    private GameObject unitGame;


    public TMP_Text roundOverText;
    public Vector3 unitPosition;
    private RoundManager roundManager;




    // currency variables
    public int currentCurrency = 0;
    public int startingCurrency = 100;
    public Text currencyText = null;
    public AudioSource coincollect;

    public static GameManager instance;

    private void Awake()
    {
        roundOverText.gameObject.SetActive(false);
        instance = this;
        Debug.Log("instance assignment.");
    }

    void Start()
    {
        roundManager = FindObjectOfType<RoundManager>();
        currentCurrency = startingCurrency;
        currencyText = GameObject.Find("Currency").GetComponent<Text>();
        currencyText.text = "$ " + currentCurrency.ToString();
    }

    public void PlaceObject(int price)
    {
        if (draggingUnit != null && currentContainer != null && currentCurrency > 0 && currentCurrency - price >= 0)
        {
            unitGame = Instantiate(draggingUnit.GetComponent<UnitDrag>().card.unitGame, currentContainer.transform);
            //unitPosition = draggingUnit.transform.position;
            currentContainer.GetComponent<UnitContainer>().isFull = true;
            // Debug.Log("Orignal unit position: " + currentContainer.transform.position);
            // Debug.Log("draggin unit position: " + draggingUnit.transform.position);
            UpdateCurrency(-price);
        }
    }

    public void UpdateCurrency(int amount)
    {
        currentCurrency += amount;
        if (amount > 0) {
            coincollect.Play();
        }
        if (currencyText != null)
        {
            currencyText.text = "$ " + currentCurrency.ToString();
        }
    }

    public void RoundOver()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (roundManager != null && roundManager.GetRoundTimer() <= 0f && enemies.Length == 0)
        {
            Debug.Log("round over called!");
            roundOverText.gameObject.SetActive(true);
            roundOverText.text = "Round Over!";
            StartCoroutine(LoadMainMenuAfterDelay(3f));
        }
    }

    public void RoundOverLose()
    {
        roundOverText.gameObject.SetActive(true);
        roundOverText.text = "Round Over!";
        StartCoroutine(LoadMainMenuAfterDelay(3f));
    }

    private void removeCoins()
    {
        CoinController coinController = FindObjectOfType<CoinController>();
        coinController.FinishGame();
    }

    private IEnumerator LoadMainMenuAfterDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene("MainMenu");
    }
}
