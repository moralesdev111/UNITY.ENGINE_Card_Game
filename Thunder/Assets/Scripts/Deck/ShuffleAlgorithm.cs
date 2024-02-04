using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleAlgorithm : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerDeck playerDeck;

    public void ShuffleDeck()
    {
        Debug.Log("Shuffle Completed");
        for(int i = 0; i < playerDeck.CurrentSize; i++)
        {
            int randomIndex = Random.Range(i, playerDeck.CurrentSize);
            SwapCards(i,randomIndex);            
        }
    }

    private void SwapCards(int indexA, int indexB)
    {
        Card temporaryCard = playerDeck.Container[indexA];

        playerDeck.Container[indexA] = playerDeck.Container[indexB];
        playerDeck.Container[indexB] = temporaryCard;
    }
}
