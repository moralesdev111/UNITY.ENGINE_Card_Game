using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public List<Card> cardDatabase = new List<Card>();

    private void Start()
    {
        foreach(Card card in cardDatabase)
        {
            Debug.Log(card.cardName + " in the database registered");
        }
    }
}
