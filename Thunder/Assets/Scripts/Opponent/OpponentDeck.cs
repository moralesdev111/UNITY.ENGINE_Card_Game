using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentDeck : SlotContainer
{
    [SerializeField] DrawCard drawCard;
    [SerializeField] CardDatabase cardDatabase;


    private void Awake()
    {
        ContainerSizeLimit = 15;
        container = new List<Card>();
        RandomizeContainer();
    }
    

    void Update()
    {
        UpdateContainerSize();
    }

    public override void RandomizeContainer()
    {
        for (int i = 0; i < ContainerSizeLimit; i++)
        {
            Card randomCard = drawCard.DrawOneRandomCard(cardDatabase.cardDatabase);
            if (randomCard != null)
            {
                Container.Add(randomCard);                
            }
            else
            {
                Debug.LogWarning("Unable to get an Opponent random card from the database.");
            }
        }
    }
}
