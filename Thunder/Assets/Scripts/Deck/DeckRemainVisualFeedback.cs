using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckRemainVisualFeedback : MonoBehaviour
{
    [SerializeField] PlayerDeck playerDeck;
    public GameObject cardInpile;
    public GameObject cardInpile2;
    public GameObject cardInpile3;
    public GameObject cardInpile4;


    void Update()
    {
        VisualFeedBack();
    }
    private void VisualFeedBack()
    {
        if(playerDeck.CurrentDeckSize < 15)
        {
            cardInpile.SetActive(false);
        }
        if(playerDeck.CurrentDeckSize < 10)
        {
            cardInpile2.SetActive(false);
        }
        if(playerDeck.CurrentDeckSize < 5)
        {
            cardInpile3.SetActive(false);
        }
        if(playerDeck.CurrentDeckSize < 1)
        {
            cardInpile4.SetActive(false);
        }
    }
}
