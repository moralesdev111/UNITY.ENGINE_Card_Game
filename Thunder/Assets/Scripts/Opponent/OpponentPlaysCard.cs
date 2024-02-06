using System.Collections;
using UnityEngine;

public class OpponentPlaysCard : MonoBehaviour
{
    [SerializeField] TurnState turnState;
    [SerializeField] GameSettings gameSettings;
    [SerializeField] OpponentHand opponentHand;
    [SerializeField] Transform opponentBattlefield;
    private bool hasPlayedCard = false;



    void Update()
    {
        if (turnState.currentTurnState == TurnState.TurnStates.playerTurn)
        {
            hasPlayedCard = false;
        }
        if (!hasPlayedCard && turnState.currentTurnState == TurnState.TurnStates.opponentTurn)
        {
            StartCoroutine(SlowDownAI());
            hasPlayedCard = true;
        }
    }

    private void PlayCard()
    {
        if (gameSettings.opponentCurrentMana > 0)
        {
            SearchForCheapCard(opponentHand.CurrentSize);
        }
        else
        {
            return;
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

    private void SearchForCheapCard(int amountOfChecks)
    {
        for (int i = 0; i < amountOfChecks; i++)
        {
            if (opponentHand.Container[i].manaCost <= gameSettings.opponentCurrentMana)
            {
                Card chosenCard = opponentHand.Container[i];
                GameObject physicalCard = opponentHand.GetInstantiatedCards()[i];
                UncoverCard(physicalCard);
                physicalCard.transform.SetParent(opponentBattlefield);
                
                AssignCardInstance(chosenCard, physicalCard);
                opponentHand.Container.Remove(chosenCard);
                opponentHand.GetInstantiatedCards().Remove(physicalCard);
                return;
            }
            else
            {
                Debug.Log("No cheap cards");
            }
        }
    }

    IEnumerator SlowDownAI()
    {
        yield return new WaitForSeconds(3f);
        PlayCard();
    }
}
