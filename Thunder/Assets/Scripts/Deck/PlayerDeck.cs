using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;


public class PlayerDeck : SlotContainer
{
    [Header("References")]
   [SerializeField] DrawCard drawCard;
   [SerializeField] CardDatabase cardDatabase;

    void Awake()
    {
        ContainerSizeLimit = 15;
        container = new List<Card>();
        RandomizeContainer();
    }

    void Update()
    {
        UpdateCurrentDeckSize();
    }

    public override void RandomizeContainer()
    {
        for (int i = 0; i < ContainerSizeLimit; i++)
        {
            Card randomCard = drawCard.DrawOneRandomCard(cardDatabase.cardDatabase);

            if (randomCard != null)
            {
                randomCard.cardState = Card.CardState.deck;
                Container.Add(randomCard);                
            }
            else
            {
                Debug.LogWarning("Unable to get a random card from the database.");
            }
        }
    }

    private void UpdateCurrentDeckSize()
    {
        CurrentSize = Container.Count;
    }
}