using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] public Slider slider;




    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateHealthBar(float currentHealth, float maxHealth)
    {
        slider.value = currentHealth / maxHealth;
    }
}
