using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAttack : MonoBehaviour
{
    [SerializeField] Transform playerBattlefield;
    [SerializeField] Transform opponentBattlefield;
    [SerializeField] PlayerHealth playerHealth;
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
                        AttackHero();
                        readyToAttack = false;
                        attackExecuted = true;
                    }
                    else
                    {
                        AttackCard();
                        readyToAttack = false;
                        attackExecuted = true;
                    } 
                }
            }
        }
    }

    private void AttackHero()
    {
        Debug.Log("Attack Hero");
        Transform selectedCard = ChooseRandomBattlefieldCard(opponentBattlefield);

        CardInstance cardInstance = selectedCard.GetComponent<CardInstance>();

        playerHealth.currentHealth -= cardInstance.card.attack;
    }

    private void AttackCard()
    {
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

}
