using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject unitDrag;
    public GameObject unitGame;
    public Canvas canvas;
    private GameObject unitDragInstance;
    public GameManager gameManager;
    public Image unitSprite;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public void OnDrag(PointerEventData eventData)
    {
        unitDragInstance.transform.position = Input.mousePosition;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        unitDragInstance = Instantiate(unitDrag, canvas.transform);
        unitDragInstance.transform.position = Input.mousePosition;
        unitDragInstance.GetComponent<UnitDrag>().card = this;
        unitDragInstance.GetComponent<Image>().sprite = unitSprite.sprite;
        gameManager.draggingUnit = unitDragInstance;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        gameManager.PlaceObject(unitGame.GetComponent<UnitGame>().price);
        Destroy(unitDragInstance);
        gameManager.draggingUnit = null;
    }
}
