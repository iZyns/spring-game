using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject currencyPrefab;
    private string targetTag = "EnemyPoint"; // The tag of the target GameObject
    public float movementSpeed = 5f; // The speed at which the enemy moves towards the target
    public Transform enemyWaypoint;
    private GameObject target; // Reference to the target GameObject
    private bool hasReachedTarget = false; // Flag indicating whether the enemy has reached the target
    public GameManager gameManager;
    public RoundManager roundManager;
    public int rewardAmount = 10;

    private GameObject coinContainer;

    [SerializeField] public HealthBar healthbar;

    // Sound effect
    [SerializeField] public AudioSource axeHitEffect;

    // Health field
    public float health = 1f;
    public float max = 1f;

    float fireBallDamage = 0.55f;
    float axeDamage = 0.15f;
    float arrowDamage = 0.30f;

    private void Start()
    {
        coinContainer = GameObject.Find("Coin Container");
        gameManager = GameManager.instance;
        target = GameObject.FindGameObjectWithTag(targetTag);
        healthbar = GetComponentInChildren<HealthBar>();
        roundManager = FindObjectOfType<RoundManager>();
    }

    private void Update()
    {
        if (!hasReachedTarget)
        {
            if (enemyWaypoint != null)
            {
                MoveTowardsWaypoint();
            }
        }
    }

    private void MoveTowardsWaypoint()
    {
        Vector2 direction = (enemyWaypoint.position - transform.position).normalized;
        Vector2 movement = direction * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            hasReachedTarget = true;
            Destroy(gameObject);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i]);
            }
            roundManager.EndRound();
            gameManager.RoundOverLose();
        }
        else if (other.tag == "fireBall")
        {
            axeHitEffect.Play();
            takeDamage(fireBallDamage);
            if (health <= 0)
            {
                spawnCoin();
                Destroy(gameObject);
            }
        }
        else if (other.tag == "Axe")
        {
            axeHitEffect.Play();
            takeDamage(axeDamage);
            if (health <= 0)
            {
                spawnCoin();
                Destroy(gameObject);
            }
        }
        else if (other.tag == "Arrow")
        {
            axeHitEffect.Play();
            takeDamage(arrowDamage);
            if (health <= 0)
            {
                spawnCoin();
                Destroy(gameObject);
            }
        }
        else if (other.tag == "player")
        {
            takeDamage(0.50f);
            Destroy(other.gameObject);
            if (health <= 0)
            {
                spawnCoin();
                Destroy(gameObject);
            }
        }
    }

    public void takeDamage(float weaponDamage)
    {
        health -= weaponDamage;
        healthbar.updateHealthBar(health, max);
    }

    private void OnDestroy()
    {


    }

    private void spawnCoin()
    {
        if (currencyPrefab != null)
        {
            GameObject coin = Instantiate(currencyPrefab, transform.position, Quaternion.identity);
            coin.transform.SetParent(coinContainer.transform);
        }
    }
}