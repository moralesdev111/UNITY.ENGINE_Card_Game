using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnLogistics : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;
    [SerializeField] Hand hand;
    [SerializeField] OpponentHand opponentHand;
    [SerializeField] TurnState turnState;


    public void LogisticsForPlayer()
    {
        gameSettings.isPlayerTurn = true;
        gameSettings.playerTurn += 1;

        gameSettings.maxMana += 1;
        gameSettings.currentMana = gameSettings.maxMana;
        gameSettings.startTurn = true;

        hand.StartDrawProcess();

        turnState.currentTurnState = TurnState.TurnStates.playerTurn;
    }

    public void LogisticsForOpponent()
    {
        gameSettings.isPlayerTurn = false;
        this.gameSettings.opponentTurn += 1;

        gameSettings.opponentMaxMana += 1;
        gameSettings.opponentCurrentMana = gameSettings.opponentMaxMana;

        gameSettings.startTurn = false;

        opponentHand.StartDrawProcess();
        
        turnState.currentTurnState = TurnState.TurnStates.opponentTurn;
    }
}
