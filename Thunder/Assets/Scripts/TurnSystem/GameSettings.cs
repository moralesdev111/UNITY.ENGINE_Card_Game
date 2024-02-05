using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public int maxMana;
    public int currentMana;
    public bool startTurn = false;
    public bool isPlayerTurn;
    public int playerTurn;
    public int opponentTurn;
    

    public void InitialTurnSettings()
    {
        isPlayerTurn = true;
        playerTurn = 1;
        opponentTurn = 0;
       
        maxMana = 1;
        currentMana = 1;
    }
}
