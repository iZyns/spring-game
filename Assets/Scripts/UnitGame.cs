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

    private int randomNumber;

    // firing time
    public float timer = 0f;
    public float interval = 1f;


    public void OnPointerDown(PointerEventData eventData)
    {

    }



    public void Start()
    {

        manageGame = GameManager.instance;

        randomNumber = Random.Range(1, 4);
    }

    public void Update()
    {

        timer += Time.deltaTime;

        if (timer >= interval)
        {

            if (randomNumber == 1)
            {
                Instantiate(fireShootingObj, transform);
            }

            if (randomNumber == 2)
            {
                Instantiate(throwAxeObj, transform);
            }
            if (randomNumber == 3)
            {
                Instantiate(launchArrow, transform);
            }
            timer = 0;
        }
    }
}
