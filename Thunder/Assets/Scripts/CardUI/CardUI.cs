using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Card cardInstance;
    [Header("References")]
    [SerializeField] TextMeshProUGUI cardName;
    [SerializeField] Image artworkImage;
    [SerializeField] Image cardBack;
    [SerializeField] TextMeshProUGUI manaCost;
    [SerializeField] TextMeshProUGUI attack;
    [SerializeField] TextMeshProUGUI health;
    private bool isInitialized = false;

    private void Start()
    {
        if (isInitialized)
        {
            return; 
        }
        if (cardInstance != null)
        {
            SetCardUI();
            isInitialized = true;
        }
    }

    public void SetCardUI()
    {
        cardName.text = cardInstance.cardName;
        artworkImage.sprite = cardInstance.artwork;
        cardBack.sprite = cardInstance.cardBack;
        manaCost.text = cardInstance.manaCost.ToString();
        attack.text = cardInstance.attack.ToString();
        health.text = cardInstance.health.ToString();
    }
}