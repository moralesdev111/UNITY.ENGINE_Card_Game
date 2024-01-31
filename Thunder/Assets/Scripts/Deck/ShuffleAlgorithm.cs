using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleAlgorithm : MonoBehaviour
{
    [SerializeField] PlayerDeck playerDeck;

    public void ShuffleDeck()
    {
        Debug.Log("Shuffle Completed");
        for(int i = 0; i < playerDeck.CurrentDeckSize; i++)
        {
            int randomIndex = Random.Range(i, playerDeck.CurrentDeckSize);
            SwapCards(i,randomIndex);            
        }
    }

    private void SwapCards(int indexA, int indexB)
    {
        Card temporaryCard = playerDeck.PlayerDeckList[indexA];

        playerDeck.PlayerDeckList[indexA] = playerDeck.PlayerDeckList[indexB];
        playerDeck.PlayerDeckList[indexB] = temporaryCard;
    }
}
