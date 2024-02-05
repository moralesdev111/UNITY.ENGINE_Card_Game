using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBack : MonoBehaviour, IUncoverCardeable
{
    [Header("References")]
    [SerializeField] GameObject cardBack;
    private bool cardBackActive;

   
    void Update()
    {
        OnOffCardBack();
    }

    private void OnOffCardBack()
    {
        if(cardBackActive)
        {
            cardBack.SetActive(true);
        }
        else 
        {
            cardBack.SetActive(false);
        }
    }

    public void UncoverCard()
    {
        cardBackActive = false;
    }
}
