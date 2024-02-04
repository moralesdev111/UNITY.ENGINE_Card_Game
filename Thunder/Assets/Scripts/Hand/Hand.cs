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
        ContainerSizeLimit = 3;
        container = new List<Card>();
        RandomizeContainer();
        UncoverCards();
    }

    void Update()
    {
        UpdateCurrentHandSize();
    }

   public override void RandomizeContainer()
    {
        for (int i = 0; i < ContainerSizeLimit; i++)
        {
            Card randomCard = drawCard.DrawRandomCard(playerDeck.Container);
            if (randomCard != null)
            {
                GameObject newCardObject = drawToHand.InstantiateInHand();
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
        for(int i = 0; i < 3; i++)
        {
            Transform child = transform.GetChild(i);
            child.GetComponent<CardBack>().UncoverCards();
        }
    }


    private void UpdateCurrentHandSize()
    {
        CurrentSize = Container.Count;
    }
}
