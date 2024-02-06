using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpponentHand : SlotContainer
{
    [SerializeField] OpponentDeck opponentDeck;
    [SerializeField] DrawCard drawCard;
    [SerializeField] DrawToHand drawToHand;
    private List<GameObject> instantiatedCards = new List<GameObject>();
   private string tagName = "Opponent";

    void Start()
    {
        ContainerSizeLimit = 5;
        container = new List<Card>();
        RandomizeContainer();
    }

    void Update()
    {
        UpdateContainerSize();
    }

    public override void RandomizeContainer()
    {
        for (int i = 0; i < 3; i++)
        {
            StartDrawProcess();
        }
    }

    public void StartDrawProcess()
    {
        if (CurrentSize < ContainerSizeLimit)
        {
            Card randomCard = drawCard.DrawOneRandomCard(opponentDeck.Container);
            if (randomCard != null)
            {
                GameObject newCardObject = drawToHand.VisualInstantiateInHand();
                newCardObject.tag = tagName;
                CardInstance cardInstance = newCardObject.GetComponent<CardInstance>();
                cardInstance.card = randomCard;
                
                container.Add(randomCard);
                instantiatedCards.Add(newCardObject);
            }
            else
            {
                Debug.LogWarning("Unable to get a random card from the database.");
            }
        }
    }

     public List<GameObject> GetInstantiatedCards()
    {
        return instantiatedCards;
    }

}