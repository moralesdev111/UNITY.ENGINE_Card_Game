using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Attack : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] CardInstance cardInstance;
    [SerializeField] Image cardImage;
    [SerializeField] GameObject targetingSystemPrefab;
    private TurnActions turnActions;
    private OpponentHealth enemyHealth;
    public bool canAttack;

    private void OnEnable()
    {
        ComponentSetup();
        turnActions.onEndTurn += ResetAttackFlag;
    }

    private void OnDisable()
    {
        turnActions.onEndTurn -= ResetAttackFlag;
    }

    private void Update()
    {
        HighlightCard(canAttack);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (cardInstance.currentCardState == CardInstance.CardState.battlefield && turnActions.turnState.currentTurnState == TurnState.TurnStates.playerTurn && canAttack)
        {
            Instantiate(targetingSystemPrefab, eventData.pointerDrag.transform);
            
        }
    }

    private void ResetAttackFlag(bool opponentTurn)
    {
        if (!opponentTurn && cardInstance.currentCardState == CardInstance.CardState.battlefield)
        {
            canAttack = true;
        }
        else if(turnActions.turnState.currentTurnState == TurnState.TurnStates.opponentTurn)
        {
            canAttack = false;
        }
    }

    private void HighlightCard(bool canAttack)
    {
        cardImage.color = canAttack ? Color.red : Color.black;
    }

    private void ComponentSetup()
    {
        canAttack = false;
        cardInstance = GetComponent<CardInstance>();
        turnActions = FindObjectOfType<TurnActions>();
        enemyHealth = FindObjectOfType<OpponentHealth>();
    }
}
