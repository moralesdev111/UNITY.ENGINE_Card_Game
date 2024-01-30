using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBack : MonoBehaviour
{
    public GameObject cardBack;
    public bool cardBackActive;

   
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
