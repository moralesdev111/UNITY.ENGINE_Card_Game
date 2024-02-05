using UnityEngine;
using TMPro;

public class TurnActions : MonoBehaviour
{
    [Header("References")]
    public TurnState turnState;
    [SerializeField] TextMeshProUGUI turnText;
    [SerializeField] TextMeshProUGUI manaText;
    [SerializeField] Hand hand;
    [SerializeField] GameSettings gameSettings;

    // Define a delegate for the end of turn
    public delegate void EndTurnDelegate(bool opponentTurn);
    public EndTurnDelegate onEndTurn;

    void Update()
    {
        manaText.text = gameSettings.currentMana + " / " + gameSettings.maxMana;
    }

    public void Actions()
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

    public void End(bool opponentTurn)
    {
        if(opponentTurn)
        {
            gameSettings.isPlayerTurn = false;
            this.gameSettings.opponentTurn += 1;
            gameSettings.startTurn = false;
            turnState.currentTurnState = TurnState.TurnStates.opponentTurn;
        }
        else
        {
            gameSettings.isPlayerTurn = true;
            gameSettings.playerTurn += 1;

            gameSettings.maxMana+= 1;
            gameSettings.currentMana = gameSettings.maxMana;
            gameSettings.startTurn = true;
            
            hand.StartDrawProcess();

            turnState.currentTurnState = TurnState.TurnStates.playerTurn;
        }

        // Invoke the delegate to notify subscribers
        onEndTurn?.Invoke(opponentTurn);
    }
}
