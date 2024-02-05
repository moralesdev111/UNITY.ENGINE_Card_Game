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
            isInitialized = true;
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
        health.text = card.health.ToString();
    }
}