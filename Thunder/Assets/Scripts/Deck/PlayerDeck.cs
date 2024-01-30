using Unity.VisualScripting;
using UnityEngine;


public class PlayerDeck : MonoBehaviour
{
    public Card[] playerDeck;
    [SerializeField] CardDatabase cardDatabase;
    public int deckSizeLimit = 15;
   


    void Start()
    {
        playerDeck = new Card[deckSizeLimit];
        SetPlayerInitialRandomHand();
    }

    private Card[] SetPlayerInitialRandomHand()
    {
       for(int i = 0; i < deckSizeLimit; i++)
       {
        Card randomCard = cardDatabase.GetRandomCard();

        if(randomCard!= null)
        {
            playerDeck[i] = randomCard;
        }
        else
        {
            Debug.LogWarning("Unable to get a random card from the database.");
        }        
       }
       return playerDeck;
    } 
}
