using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [SerializeField] Card card;
    [SerializeField] TextMeshProUGUI cardName;
    [SerializeField] Image artworkImage;
    [SerializeField] TextMeshProUGUI manaCost;
    [SerializeField] TextMeshProUGUI attack;
    [SerializeField] TextMeshProUGUI health;
    

    private void Awake()
    {  
        SetCardUI();
    }

    private void SetCardUI()
    {
        cardName.text = card.cardName;
        artworkImage.sprite = card.artwork;
        manaCost.text = card.manaCost.ToString();
        attack.text = card.attack.ToString();
        health.text = card.health.ToString();
    }
}
