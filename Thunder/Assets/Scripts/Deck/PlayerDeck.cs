using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;


public class PlayerDeck : MonoBehaviour
{
    [SerializeField] CardDatabase cardDatabase;
    [SerializeField] private int currentDeckSize;
    public int DeckSizeLimit { get; private set; } = 15;
    
    public int CurrentDeckSize 
    {
        get{return PlayerDeckList.Count;}
        private set{currentDeckSize = value;}
    }
    private List<Card> playerDeck;
    public List<Card> PlayerDeckList
    {
        get { return playerDeck; }
    }

    void Start()
    {
        playerDeck = new List<Card>();
        SetPlayerInitialRandomDeck();
    }

    void Update()
    {
        UpdateCurrentDeckSize();
    }

    private void SetPlayerInitialRandomDeck()
    {
        for (int i = 0; i < DeckSizeLimit; i++)
        {
            Card randomCard = cardDatabase.GetRandomCard();

            if (randomCard != null)
            {
                playerDeck.Add(randomCard);                
            }
            else
            {
                Debug.LogWarning("Unable to get a random card from the database.");
            }
        }
    }

    private void UpdateCurrentDeckSize()
    {
        currentDeckSize = PlayerDeckList.Count;
    }
}
