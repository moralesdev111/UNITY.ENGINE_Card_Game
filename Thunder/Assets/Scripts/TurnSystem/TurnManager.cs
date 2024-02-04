using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnManager : MonoBehaviour
{
    public bool isPlayerTurn;
    public int playerTurn;
    public int opponentTurn;
    public int maxMana;
    public int currentMana;
    [SerializeField] TurnState turnState;
    [SerializeField] TextMeshProUGUI manaText;
    [SerializeField] TurnActions turnActions;

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
        manaText.text = currentMana + " / " + maxMana;
    }

    public void EndPlayerTurn()
    {
        if(isPlayerTurn)
        {
           turnActions.End(true);
        }
    }

    public void EndOpponentTurn()
    {
        if(!isPlayerTurn)
        {
            turnActions.End(false);
        }
    }
}
