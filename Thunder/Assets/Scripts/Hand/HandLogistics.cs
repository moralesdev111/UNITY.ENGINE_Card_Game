using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLogistics : MonoBehaviour, IUncoverCardeable
{
    [SerializeField] Hand hand;


    public void UncoverCard()
    {
        for (int i = 0; i < hand.CurrentSize; i++)
        {
            Transform child = transform.GetChild(i);
            child.GetComponent<CardBack>().UncoverCard();
        }
    }

    public void SetHandState()
    {
        foreach (Transform childTransform in transform)
        {
            CardInstance cardInstance = childTransform.GetComponent<CardInstance>();
            if (cardInstance != null)
            {
                cardInstance.currentCardState = CardInstance.CardState.hand;
            }
            else
            {
                return;
            }
        }
    }

    

    
}
