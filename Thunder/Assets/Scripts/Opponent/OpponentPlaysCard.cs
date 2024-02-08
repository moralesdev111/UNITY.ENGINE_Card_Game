using System.Collections;
using UnityEngine;

public class OpponentPlaysCard : MonoBehaviour
{
    [SerializeField] TurnState turnState;
    [SerializeField] GameSettings gameSettings;
    [SerializeField] OpponentHand opponentHand;
    [SerializeField] Transform opponentBattlefield;
    [SerializeField] OpponentAttack opponentAttack;
    [SerializeField] TurnManager turnManager;
    private bool hasPlayedCard = false;



    void Update()
    {
        if (turnState.currentTurnState == TurnState.TurnStates.playerTurn)
        {
            hasPlayedCard = false;
            opponentAttack.attackExecuted = false;
        }
        if (!hasPlayedCard && turnState.currentTurnState == TurnState.TurnStates.opponentTurn)
        {
            PlayCard();
            hasPlayedCard = true;
            opponentAttack.readyToAttack = true;
            opponentAttack.attackExecuted = false;
        }
    }

    private void PlayCard()
    {
        if (gameSettings.opponentCurrentMana > 0)
        {
            StartCoroutine(DelayAction());
        }
        else
        {
            return;
        }
    }

    private void SearchForFirstPlayableCard(int amountOfChecks)
    {
        bool foundPlayableCard = false;
        for (int i = 0; i < amountOfChecks; i++)
        {
            if (opponentHand.Container[i].manaCost <= gameSettings.opponentCurrentMana)
            {
                foundPlayableCard = true;
                Card chosenCard = opponentHand.Container[i];
                GameObject physicalCard = opponentHand.GetInstantiatedCards()[i];
                UncoverCard(physicalCard);
                physicalCard.transform.SetParent(opponentBattlefield);
                
                AssignCardInstance(chosenCard, physicalCard);
                opponentHand.Container.Remove(chosenCard);
                opponentHand.GetInstantiatedCards().Remove(physicalCard);
                break;
            }
        }
        if(!foundPlayableCard)
        {
            turnManager.EndOpponentTurn();
            Debug.Log("No card is playable");
        }
    }

    private void AssignCardInstance(Card chosenCard, GameObject physicalCard)
    {
        CardInstance cardInstance = physicalCard.GetComponent<CardInstance>();
        cardInstance.card = chosenCard;
    }

    private void UncoverCard(GameObject physicalCard)
    {
        CardBack randomizedCardBack = physicalCard.GetComponent<CardBack>();
        randomizedCardBack.UncoverCard();
    }

    IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(1.5f);
        SearchForFirstPlayableCard(opponentHand.CurrentSize);
    }
}
