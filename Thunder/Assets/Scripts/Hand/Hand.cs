using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : SlotContainer, IUncoverCardeable
{
    [Header("References")]
    [SerializeField] PlayerDeck playerDeck;
    [SerializeField] DrawToHand drawToHand;
    [SerializeField] DrawCard drawCard;
   

    void Start()
    {
        ContainerSizeLimit = 5;
        container = new List<Card>();
        RandomizeContainer();
        
    }

    void Update()
    {
        UpdateCurrentHandSize();
        UncoverCards();
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
        if(CurrentSize < ContainerSizeLimit)
        {
            Card randomCard = drawCard.DrawOneRandomCard(playerDeck.Container);
        if (randomCard != null)
        {
            GameObject newCardObject = drawToHand.VisualInstantiateInHand();
            CardUI randomizedCardUI = newCardObject.GetComponent<CardUI>();
            randomizedCardUI.card = randomCard;

            container.Add(randomCard);
        }
        else
        {
            Debug.LogWarning("Unable to get a random card from the database.");
        }
        }
        
    }

    public void UncoverCards()
    {
        for(int i = 0; i < CurrentSize; i++)
        {
            Transform child = transform.GetChild(i);
            child.GetComponent<CardBack>().UncoverCards();
        }
    }


    public void UpdateCurrentHandSize()
    {
        CurrentSize = Container.Count;
    }
}
