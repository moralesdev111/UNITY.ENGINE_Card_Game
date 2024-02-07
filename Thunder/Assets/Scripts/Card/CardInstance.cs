using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardInstance : MonoBehaviour
{
    public Card card;
    [Header("References")]
    [SerializeField] TextMeshProUGUI cardName;
    [SerializeField] Image artworkImage;
    [SerializeField] Image cardBack;
    [SerializeField] TextMeshProUGUI manaCost;
    [SerializeField] TextMeshProUGUI attack;
    [SerializeField] TextMeshProUGUI health;
    public int healthInstanceMaxHealth;
    public int healthInstanceCurrentHealth;
    private bool isInitialized = false;

        public enum CardState
    {
        deck,
        hand,
        battlefield,
        discard
    }
     public CardState currentCardState;

    private void Start()
    {
        SetHierarchyName();
        SetInitialState();
        if (isInitialized)
        {
            return;
        }
        if (card != null)
        {
            SetCardUI();
            healthInstanceMaxHealth = card.health;
            healthInstanceCurrentHealth = healthInstanceMaxHealth;
            isInitialized = true;
        }
    }

    private void Update()
    {
        health.text = healthInstanceCurrentHealth.ToString();
        if(healthInstanceCurrentHealth < 1)
        {
            Destroy(gameObject);
        }
    }

    
    private void SetInitialState()
    {
        currentCardState = CardState.deck;
    }

    private void SetHierarchyName()
    {
        this.name = card.cardName;
    }

    public void SetCardUI()
    {
        cardName.text = card.cardName;
        artworkImage.sprite = card.artwork;
        cardBack.sprite = card.cardBack;
        manaCost.text = card.manaCost.ToString();
        attack.text = card.attack.ToString();
        health.text = healthInstanceCurrentHealth.ToString();
    }
}