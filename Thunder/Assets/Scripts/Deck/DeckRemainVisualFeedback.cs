using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckRemainVisualFeedback : MonoBehaviour
{
    [SerializeField] PlayerDeck playerDeck;
    [SerializeField] GameObject cardInpile;
    [SerializeField] GameObject cardInpile2;
    [SerializeField] GameObject cardInpile3;
    [SerializeField] GameObject cardInpile4;


    void Update()
    {
        VisualFeedBack();
    }
    private void VisualFeedBack()
{
    if (playerDeck.CurrentDeckSize < 15)
    {
        cardInpile.SetActive(false);
    }
    else
    {
        cardInpile.SetActive(true);
    }

    if (playerDeck.CurrentDeckSize < 10)
    {
        cardInpile2.SetActive(false);
    }
    else
    {
        cardInpile2.SetActive(true);
    }

    if (playerDeck.CurrentDeckSize < 5)
    {
        cardInpile3.SetActive(false);
    }
    else
    {
        cardInpile3.SetActive(true);
    }

    if (playerDeck.CurrentDeckSize < 1)
    {
        cardInpile4.SetActive(false);
    }
    else
    {
        cardInpile4.SetActive(true);
    }
}

}
