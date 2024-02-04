using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Draw Card", menuName = "ScriptableObjects/Draw Card")]
public class DrawCard : ScriptableObject
{
    public Card DrawOneRandomCard(List<Card> cardList)
    {
        if(cardList.Count > 0)
        {
            int randomIndex = Random.Range(0,cardList.Count);
            return cardList[randomIndex];
        }
        else
        {
            Debug.Log("CardDatabase is empty");
            return null;
        }
    }
}
