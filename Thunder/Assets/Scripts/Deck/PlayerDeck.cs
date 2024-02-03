using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;


public class PlayerDeck : HandContainer
{
   [SerializeField] CardDatabase cardDatabase;

    void Start()
    {
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
            Card randomCard = cardDatabase.GetRandomCard();

            if (randomCard != null)
            {
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
