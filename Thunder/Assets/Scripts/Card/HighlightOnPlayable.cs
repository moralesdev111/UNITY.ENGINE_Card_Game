using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighlightOnPlayable : MonoBehaviour
{
    [SerializeField] CardInstance cardInstance;
    [SerializeField] Image cardImage;
    private TurnActions turnActions;
    private ManaManager manaManager;

    void OnEnable()
    {
        turnActions = FindObjectOfType<TurnActions>();
        manaManager = FindObjectOfType<ManaManager>();
    }

    void Update()
    {
        if(turnActions.turnState.currentTurnState == TurnState.TurnStates.playerTurn)
        {
            if(cardInstance.currentCardState == CardInstance.CardState.hand)
            {
                if(manaManager.GreenLight(cardInstance.card))
                {
                    cardImage.color = Color.blue;
                }
                else
                {
                    cardImage.color = Color.black;
                }
            }
        }
    }
}
