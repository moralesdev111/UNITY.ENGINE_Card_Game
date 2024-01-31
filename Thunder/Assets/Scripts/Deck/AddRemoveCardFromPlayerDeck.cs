using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRemoveCardFromPlayerDeck : MonoBehaviour
{
    [SerializeField] PlayerDeck playerDeck;
    [SerializeField] CardDatabase cardDatabase;

    

    public void RemoveCard()
    {
        if(playerDeck.PlayerDeckList.Count >= 1)
        {
            Debug.Log("1 card removed");
        playerDeck.PlayerDeckList.RemoveAt(2);
        }
        else
        {
            Debug.Log("No cards left");
            return;
        }
        
    }
    public void AddCard()
    {
        if(playerDeck.PlayerDeckList.Count < playerDeck.DeckSizeLimit)
        {
             Debug.Log("1 card added");
        playerDeck.PlayerDeckList.Add(cardDatabase.GetRandomCard());
        }
        else{
            Debug.Log("Cant add more cards");
            return;
        }
       
    }
}
