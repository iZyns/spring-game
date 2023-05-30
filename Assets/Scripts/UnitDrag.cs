using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitDrag : MonoBehaviour
{
    public UnitCard card;
    public Image sprite;

    private void Start() {
        sprite = card.unitSprite;
    }
}
