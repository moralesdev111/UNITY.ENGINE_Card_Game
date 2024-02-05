
using UnityEngine;


public class TurnManager : MonoBehaviour
{
    [SerializeField] TurnState turnState;
    [SerializeField] TurnActions turnActions;
    [SerializeField] GameSettings gameSettings;

    void Start()
    {
        turnState.currentTurnState = TurnState.TurnStates.playerTurn;
        gameSettings.InitialTurnSettings();       
    }

    void Update()
    {
        turnActions.Actions();
    }

    public void EndPlayerTurn()
    {
        if(gameSettings.isPlayerTurn)
        {
           turnActions.End(true);
        }
    }

    public void EndOpponentTurn()
    {
        if(!gameSettings.isPlayerTurn)
        {
            turnActions.End(false);
        }
    }
}
