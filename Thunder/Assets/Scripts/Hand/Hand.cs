using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] CardDatabase cardDatabase;
     [SerializeField] private int currentHandSize;
    public int HandSizeLimit {get;private set;} = 3;
    public int CurrentHandSize 
    {
        get{return playerHand.Count;}
        private set{currentHandSize = value;}
    }
    private List<Card> playerHand;
    public List<Card> PlayerHandList
    {
        get{return playerHand;}
    }
    

    void Start()
    {
        playerHand = new List<Card>();
        SetPlayerInitialRandomHand();
    }

    void Update()
    {
         UpdateCurrentHandSize();
    }

    private void SetPlayerInitialRandomHand()
    {
        for(int i = 0; i < HandSizeLimit; i++)
        {
            Card randomCard = cardDatabase.GetRandomCard();
            if(randomCard != null)
            {
                playerHand.Add(randomCard);
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
        currentHandSize = PlayerHandList.Count;
    }
}
