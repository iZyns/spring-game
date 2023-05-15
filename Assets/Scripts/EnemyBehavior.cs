using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private string targetTag = "EnemyPoint"; // The tag of the target GameObject
    public float movementSpeed = 5f; // The speed at which the enemy moves towards the target
    public Transform enemyWaypoint;
    private GameObject target; // Reference to the target GameObject
    private bool hasReachedTarget = false; // Flag indicating whether the enemy has reached the target
    public GameManager gameManager;
    public RoundManager roundManager;
    public int rewardAmount = 10;

    [SerializeField] public HealthBar healthbar;

    //Soundeffect
    [SerializeField] public AudioSource axeHitEffect;
    // health field
    float health = 1f;
    float max = 1f;

    float fireBallDamage = 0.50f;
    float axeDamage = 0.30f;
    float arrowDamage = 0.5f;

    private void Start()
    {
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
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (other.CompareTag(targetTag))
        {
            hasReachedTarget = true;
            Destroy(gameObject);
            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i]);
            }
            roundManager.EndRound();
            gameManager.RoundOverLose();
        }
        if (other.tag == "fireBall")
        {
            axeHitEffect.Play();

            takeDamage(fireBallDamage);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (other.tag == "Axe")
        {
            axeHitEffect.Play();
            takeDamage(axeDamage);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (other.tag == "Arrow")
        {
            axeHitEffect.Play();
            takeDamage(arrowDamage);
            if (health <= 0)
            {
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
        gameManager.UpdateCurrency(rewardAmount);
    }
}