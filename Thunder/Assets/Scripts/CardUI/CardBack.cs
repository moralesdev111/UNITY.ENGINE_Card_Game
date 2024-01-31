using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBack : MonoBehaviour
{
    [SerializeField] GameObject cardBack;
    [SerializeField] bool cardBackActive;

   
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
}
