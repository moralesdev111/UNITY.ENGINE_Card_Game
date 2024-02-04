using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnSystem : MonoBehaviour
{
    public bool isPlayerTurn;
    public int playerTurn;
    public int opponentTurn;
    public int maxMana;
    public int currentMana;
    [SerializeField] TurnState turnState;
    [SerializeField] TextMeshProUGUI turnText;
    [SerializeField] TextMeshProUGUI manaText;

    void Start()
    {
        turnState.currentTurnState = TurnState.TurnStates.playerTurn;
        isPlayerTurn = true;
        playerTurn = 1;
        opponentTurn = 0;
       
        maxMana = 1;
        currentMana = 1;
    }

    void Update()
    {
        if(isPlayerTurn)
        {
            turnText.text = "Player Turn";
        }
        else
        {
            turnText.text = "Opponent Turn";
        }
        manaText.text = currentMana + " / " + maxMana;
    }

    public void EndPlayerTurn()
    {
        if(isPlayerTurn)
        {
            isPlayerTurn = false;
            opponentTurn += 1;
            turnState.currentTurnState = TurnState.TurnStates.opponentTurn;
        }

       
    }

    public void EndOpponentTurn()
    {
        if(!isPlayerTurn)
        {
            isPlayerTurn = true;
            playerTurn += 1;

            maxMana+= 1;
            currentMana = maxMana;
            turnState.currentTurnState = TurnState.TurnStates.playerTurn;
        }
       
    }
}
