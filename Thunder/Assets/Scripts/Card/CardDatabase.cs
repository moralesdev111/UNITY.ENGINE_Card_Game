using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public List<Card> cardDatabase = new List<Card>();
    
    public Card GetRandomCard()
    {
        if(cardDatabase.Count > 0)
        {
            int randomIndex = Random.Range(0,cardDatabase.Count);
            return cardDatabase[randomIndex];
        }
        else
        {
            Debug.Log("CardDatabase is empty");
            return null;
        }
    } 
}
