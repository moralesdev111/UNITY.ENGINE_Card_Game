using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnActions : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TurnState turnState;
    [SerializeField] TurnManager turnSystem;
    [SerializeField] TextMeshProUGUI turnText;
    [SerializeField] TurnManager turnManager;
    

    void Update()
    {
        Actions();
    }

   private void Actions()
    {
        if(turnState.currentTurnState == TurnState.TurnStates.playerTurn)
            {
                turnText.text = "Player Turn";   
            }
        else if(turnState.currentTurnState == TurnState.TurnStates.opponentTurn)
            {
                turnText.text = "Opponent Turn";  
            }
    }

    public void End(bool turnOwner)
    {
        if(turnOwner)
        {
            turnManager.isPlayerTurn = false;
            turnManager.opponentTurn += 1;
            turnState.currentTurnState = TurnState.TurnStates.opponentTurn;
        }
        else
        {
            turnManager.isPlayerTurn = true;
            turnManager.playerTurn += 1;

            turnManager.maxMana+= 1;
            turnManager.currentMana = turnManager.maxMana;
            turnState.currentTurnState = TurnState.TurnStates.playerTurn;
        }
    }
}
