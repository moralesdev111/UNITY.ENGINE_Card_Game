using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentDeckRemainingVisualFeedBack : MonoBehaviour
{
    [SerializeField] OpponentDeck opponentDeck;
    [SerializeField] Image cardInpileImage;
    [SerializeField] Image cardInpile2Image;
    [SerializeField] Image cardInpile3Image;
    [SerializeField] Image cardInpile4Image;

    void Update()
    {
        VisualFeedback();
    }

    private void VisualFeedback()
    {
        if (opponentDeck.CurrentSize < 15)
        {
            cardInpileImage.enabled = false;
        }
        else
        {
            cardInpileImage.enabled = true;
        }

        if (opponentDeck.CurrentSize < 10)
        {            
            cardInpile2Image.enabled = false;
        }
        else
        {
            cardInpile2Image.enabled = true;
        }

        if (opponentDeck.CurrentSize < 5)
        {         
            cardInpile3Image.enabled = false;
        }
        else
        {
            cardInpile3Image.enabled = true;
        }

        if (opponentDeck.CurrentSize < 1)
        {     
            cardInpile4Image.enabled = false;
        }
        else
        {
            cardInpile4Image.enabled = true;
        }
    }
}
