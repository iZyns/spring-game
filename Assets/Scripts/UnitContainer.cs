using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitContainer : MonoBehaviour
{
    public bool isFull;
    public GameManager gameManager;
    public Image highlight;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (gameManager.draggingUnit != null && gameManager.draggingUnit.GetComponent<UnitDrag>().GetComponent<BoxCollider2D>() == other && isFull == false)
        {
            Debug.Log(other);
            gameManager.currentContainer = this.gameObject;
            highlight.enabled = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (gameManager.draggingUnit != null && gameManager.draggingUnit.GetComponent<UnitDrag>().GetComponent<BoxCollider2D>() == other)
        {
            gameManager.currentContainer = null;
            highlight.enabled = false;
        }
    }
}
