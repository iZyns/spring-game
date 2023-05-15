using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject unitDrag;
    public GameObject unitGame;
    public Canvas canvas;
    private GameObject unitDragInstance;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        Debug.Log("gameManager instance assignment.");
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
        gameManager.draggingUnit = unitDragInstance;
        Debug.Log("draggingUnit assignment.");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        gameManager.PlaceObject();
        Destroy(unitDragInstance);
        gameManager.draggingUnit = null;
    }
}
