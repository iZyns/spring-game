using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitGame : MonoBehaviour, IPointerDownHandler
{
    // projectiles
    public GameManager manageGame;
    public GameObject fireShootingObj;
    public GameObject throwAxeObj;
    public GameObject launchArrow;
    public AudioSource shout;

    public int projectile;
    public int price;

    // firing time
    public float timer = 0f;
    public float interval = 1f;
    private UnitContainer unitContainer;

    public void OnPointerDown(PointerEventData eventData)
    {

    }



    public void Start()
    {
        unitContainer = GetComponentInParent<UnitContainer>();
        manageGame = GameManager.instance;
        shout.Play();
    }

    public void Update()
    {

        timer += Time.deltaTime;

        if (timer >= interval)
        {

            if (projectile == 1)
            {
                Instantiate(fireShootingObj, transform);
            }

            if (projectile == 2)
            {
                Instantiate(throwAxeObj, transform);
            }
            if (projectile == 3)
            {
                Instantiate(launchArrow, transform);
            }
            timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            unitContainer.isFull = false;
        }
    }
}
