using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Attack : MonoBehaviour, IPointerClickHandler
{
    private CardInstance cardInstance;
    private TurnActions turnActions;
    private EnemyHealth enemyHealth;
    public bool canAttack = true;

    private void OnEnable()
    {
        cardInstance = GetComponent<CardInstance>();
        turnActions = FindObjectOfType<TurnActions>();
        enemyHealth = FindObjectOfType<EnemyHealth>();

        // Subscribe to the End turn delegate to reset the canAttack flag
        turnActions.onEndTurn += ResetAttackFlag;
    }

    private void OnDisable()
    {
        // Unsubscribe from the End turn delegate when disabled
        turnActions.onEndTurn -= ResetAttackFlag;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (cardInstance.currentCardState == CardInstance.CardState.battlefield && turnActions.turnState.currentTurnState == TurnState.TurnStates.playerTurn && canAttack)
        {
            enemyHealth.currentHealth -= cardInstance.card.attack;
            canAttack = false;
        }
    }

    private void ResetAttackFlag(bool opponentTurn)
    {
        if (!opponentTurn)
        {
            canAttack = true;
        }
    }
}
