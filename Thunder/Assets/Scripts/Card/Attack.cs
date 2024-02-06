using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Attack : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] CardInstance cardInstance;
    [SerializeField] Image cardImage;
    private TurnActions turnActions;
    private EnemyHealth enemyHealth;
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
            enemyHealth.currentHealth -= cardInstance.card.attack;
            canAttack = false;
        }
    }

    private void ResetAttackFlag(bool opponentTurn)
    {
        if (!opponentTurn && cardInstance.currentCardState == CardInstance.CardState.battlefield)
        {
            canAttack = true;
        }
    }

    private void HighlightCard(bool canAttack)
    {
        if(canAttack)
        {
            cardImage.color = Color.red;
        }
        else
        {
            cardImage.color = Color.black;
        }
    }

    private void ComponentSetup()
    {
        canAttack = false;
        cardInstance = GetComponent<CardInstance>();
        turnActions = FindObjectOfType<TurnActions>();
        enemyHealth = FindObjectOfType<EnemyHealth>();
    }
}
