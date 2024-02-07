using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAttack : MonoBehaviour
{
    [SerializeField] Transform playerBattlefield;
    [SerializeField] Transform opponentBattlefield;
    [SerializeField] OpponentPlaysCard opponentPlaysCard;
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

        int randomIndex = UnityEngine.Random.Range(0, opponentBattlefield.childCount);
        Transform selectedCard = opponentBattlefield.GetChild(randomIndex);

        CardInstance cardInstance = selectedCard.GetComponent<CardInstance>();

        playerHealth.currentHealth -= cardInstance.card.attack;
    }

    private void AttackCard()
    {
        Debug.Log("Attack Card");
    }
}
