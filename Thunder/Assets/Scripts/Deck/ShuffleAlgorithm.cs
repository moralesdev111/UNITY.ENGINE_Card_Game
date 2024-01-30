using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleAlgorithm : MonoBehaviour
{
    [SerializeField] PlayerDeck playerDeck;

    public void ShuffleDeck()
    {
        for(int i = 0; i < playerDeck.deckSizeLimit; i++)
        {
            int randomIndex = Random.Range(i,playerDeck.deckSizeLimit);
            SwapCards(i,randomIndex);            
        }
    }

    private void SwapCards(int indexA, int indexB)
    {
        Card temporaryCard = playerDeck.playerDeck[indexA];

        playerDeck.playerDeck[indexA] = playerDeck.playerDeck[indexB];
        playerDeck.playerDeck[indexB] = temporaryCard;
    }
}
