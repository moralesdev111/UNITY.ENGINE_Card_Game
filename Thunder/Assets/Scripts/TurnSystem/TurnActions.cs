
using UnityEngine;
using TMPro;

public class TurnActions : MonoBehaviour
{
    public bool isPlayerTurn;
    public int playerTurn;
    public int opponentTurn;
    public int maxMana;
    public int currentMana;
    public bool startTurn = false;
    [Header("References")]
    [SerializeField] TurnState turnState;
    [SerializeField] TextMeshProUGUI turnText;
    [SerializeField] TextMeshProUGUI manaText;
    [SerializeField] DrawCard drawCard;
    [SerializeField] DrawToHand drawToHand;
    [SerializeField] PlayerDeck playerDeck;
    [SerializeField] Hand hand;

    void Update()
    {
        manaText.text = currentMana + " / " + maxMana;
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
            isPlayerTurn = false;
            this.opponentTurn += 1;
            startTurn = false;
            turnState.currentTurnState = TurnState.TurnStates.opponentTurn;
        }
        else
        {
            isPlayerTurn = true;
            playerTurn += 1;

            maxMana+= 1;
            currentMana = maxMana;
            startTurn = true;
            
            hand.StartDrawProcess();

            turnState.currentTurnState = TurnState.TurnStates.playerTurn;
        }
    }

    public void InitialTurnSettings()
    {
        isPlayerTurn = true;
        playerTurn = 1;
        opponentTurn = 0;
       
        maxMana = 1;
        currentMana = 1;
    }
}
