
using UnityEngine;


public class TurnManager : MonoBehaviour
{
    [SerializeField] TurnState turnState;
    [SerializeField] TurnActions turnActions;

    void Start()
    {
        turnState.currentTurnState = TurnState.TurnStates.playerTurn;
        turnActions.InitialTurnSettings();       
    }

    void Update()
    {
        turnActions.Actions();
    }

    public void EndPlayerTurn()
    {
        if(turnActions.isPlayerTurn)
        {
           turnActions.End(true);
        }
    }

    public void EndOpponentTurn()
    {
        if(!turnActions.isPlayerTurn)
        {
            turnActions.End(false);
        }
    }
}
