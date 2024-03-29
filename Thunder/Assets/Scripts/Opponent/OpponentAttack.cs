using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpponentAttack : MonoBehaviour
{
    [SerializeField] Transform playerBattlefield;
    [SerializeField] Transform opponentBattlefield;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] TurnManager turnManager;
    [SerializeField] TextMeshProUGUI playerHealthText;
    [SerializeField] AudioManager audioManager; 

    
    public bool readyToAttack = false;
    public bool attackExecuted= false;



    void Update()
    {
        if(readyToAttack)
        {
            if(!attackExecuted)
            {
                 if(opponentBattlefield.childCount > 0)
                {
                    if(playerBattlefield.childCount == 0)
                    {
                        StartCoroutine(DelayAction());
                        readyToAttack = false;
                        attackExecuted = true;
                        StartCoroutine(DelayAction3());
                    }
                    else
                    {
                        StartCoroutine(DelayAction2());
                        readyToAttack = false;
                        attackExecuted = true;
                        StartCoroutine(DelayAction3());
                    } 
                }
            }
            else
            {
                StartCoroutine(DelayAction3());
            }
        }
    }

    private void AttackHero()
    {
        audioManager.PlaySFX("attack");

        Debug.Log("Attack Hero");
        Transform selectedCard = ChooseRandomBattlefieldCard(opponentBattlefield);

        CardInstance cardInstance = selectedCard.GetComponent<CardInstance>();

        playerHealth.currentHealth -= cardInstance.card.attack;
        playerHealthText.color = Color.red;
        StartCoroutine(ChangeColorToBlack());
    }

    private void AttackCard()
    {
        
        audioManager.PlaySFX("attack");
        Debug.Log("Attack Card");

        Transform selectedCard = ChooseRandomBattlefieldCard(opponentBattlefield);
        CardInstance attackingCard = selectedCard.GetComponent<CardInstance>();

        Transform selectedEnemyCard = ChooseRandomBattlefieldCard(playerBattlefield);
        CardInstance defendingCard = selectedEnemyCard.GetComponent<CardInstance>();

        defendingCard.healthInstanceCurrentHealth -= attackingCard.card.attack;
        attackingCard.healthInstanceCurrentHealth -=  defendingCard.card.attack;
    }

     private Transform ChooseRandomBattlefieldCard(Transform battlefieldOwner)
    {
        int randomIndex = UnityEngine.Random.Range(0, battlefieldOwner.childCount);
        Transform selectedCard = battlefieldOwner.GetChild(randomIndex);
        return selectedCard;
    }

    IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(3.5f);
        AttackHero();
    }

    IEnumerator DelayAction2()
    {
        yield return new WaitForSeconds(3.5f);
        AttackCard();
    }

    private void EndTurnManager()
    {
        turnManager.EndOpponentTurn();
    }
    IEnumerator DelayAction3()
    {
        yield return new WaitForSeconds(7f);
        EndTurnManager();
    }

    IEnumerator ChangeColorToBlack()
    {
        yield return new WaitForSeconds(1.5f);
        playerHealthText.color = Color.black;
    }

}
