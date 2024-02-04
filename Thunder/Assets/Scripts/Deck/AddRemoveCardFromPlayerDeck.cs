using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRemoveCardFromPlayerDeck : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerDeck playerDeck;
    [SerializeField] DrawCard drawCard;
    [SerializeField] CardDatabase cardDatabase;

    

    public void RemoveCard()
    {
        if(playerDeck.Container.Count > 0)
        {
            Debug.Log("1 card removed");
        playerDeck.Container.RemoveAt(0);
        }
        else
        {
            Debug.Log("No cards left");
            return;
        }
        
    }
    public void AddCard()
    {
        if(playerDeck.Container.Count < playerDeck.ContainerSizeLimit)
        {
            Debug.Log("1 card added");
            playerDeck.Container.Add(drawCard.DrawOneRandomCard(cardDatabase.cardDatabase));
        }
        else
        {
            Debug.Log("Cant add more cards");
            return;
        }
       
    }
}
