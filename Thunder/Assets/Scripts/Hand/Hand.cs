using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : SlotContainer
{
    [SerializeField] CardDatabase cardDatabase;
    

    void Start()
    {
        ContainerSizeLimit = 3;
        container = new List<Card>();
        RandomizeContainer();
    }

    void Update()
    {
         UpdateCurrentHandSize();
    }

    public override void RandomizeContainer()
    {
        for(int i = 0; i < ContainerSizeLimit; i++)
        {
            Card randomCard = cardDatabase.GetRandomCard();
            if(randomCard != null)
            {
                container.Add(randomCard);
                Debug.Log(randomCard.name);
            }
            else
            {
                Debug.LogWarning("Unable to get a random card from the database.");
            }
        }
    }


    private void UpdateCurrentHandSize()
    {
        CurrentSize = Container.Count;
    }
}
