using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : SlotContainer
{
    [Header("References")]
    [SerializeField] PlayerDeck playerDeck;
    [SerializeField] DrawToHand drawToHand;
    [SerializeField] DrawCard drawCard;
    [SerializeField] HandLogistics handLogistics;

    void Start()
    {
        ContainerSizeLimit = 5;
        container = new List<Card>();
        RandomizeContainer();
        handLogistics.UncoverCard();
    }

    void Update()
    {
        UpdateCurrentHandSize();
        handLogistics.SetHandState();
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
            Card randomCard = drawCard.DrawOneRandomCard(playerDeck.Container);
            if (randomCard != null)
            {
                GameObject newCardObject = drawToHand.VisualInstantiateInHand();
                
                CardBack randomizedCardBack = newCardObject.GetComponent<CardBack>();
                randomizedCardBack.UncoverCard();

                CardInstance cardInstance = newCardObject.GetComponent<CardInstance>();
                cardInstance.card = randomCard;

                container.Add(randomCard);
            }
            else
            {
                Debug.LogWarning("Unable to get a random card from the database.");
            }
        }
    }

    public void UpdateCurrentHandSize()
    {
        CurrentSize = Container.Count;
    }
}
