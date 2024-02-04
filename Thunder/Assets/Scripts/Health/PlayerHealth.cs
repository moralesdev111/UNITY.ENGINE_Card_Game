using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;
    [SerializeField] Image healthVisual;
    [SerializeField] TextMeshProUGUI healthText;


    void Start()
    {
        currentHealth = 4;
    }

    void Update()
    {
        healthVisual.fillAmount = currentHealth / maxHealth;
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthText.text = currentHealth.ToString() + " Health";
    }
}
