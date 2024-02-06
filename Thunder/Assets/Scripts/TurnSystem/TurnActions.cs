using UnityEngine;
using TMPro;

public class TurnActions : MonoBehaviour
{
    [Header("References")]
    public TurnState turnState;
    [SerializeField] TextMeshProUGUI turnText;
    [SerializeField] TextMeshProUGUI manaText;
    [SerializeField] TextMeshProUGUI opponentManaText;
    [SerializeField] GameSettings gameSettings;
     [SerializeField] EndTurnLogistics endTurnLogistics;

    // Define a delegate for the end of turn
    public delegate void EndTurnDelegate(bool opponentTurn);
    public EndTurnDelegate onEndTurn;

    void Update()
    {
        UpdateManaText();
    }

    public void Actions()
    {
        UpdateTurnText();
    }

    public void EndTurnLogistics(bool ownerTurn)
    {
        if(ownerTurn)
        {
            endTurnLogistics.LogisticsForOpponent();
        }
        else
        {
            endTurnLogistics.LogisticsForPlayer();
        }
        onEndTurn?.Invoke(!gameSettings.isPlayerTurn);
    }
    
    private void UpdateManaText()
    {
        manaText.text = gameSettings.currentMana + " / " + gameSettings.maxMana;
        opponentManaText.text = gameSettings.opponentCurrentMana + " / " + gameSettings.opponentMaxMana;
    }

     private void UpdateTurnText()
    {
        turnText.text = turnState.currentTurnState == TurnState.TurnStates.playerTurn ? "Player Turn" : "Opponent Turn";
    }
}
