using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BattleManager : MonoBehaviour
{
    public CardInstance[] battlingCards;
    public bool canBattle = true;
   

    void Start()
    {
        battlingCards = new CardInstance[2];
    }

    private void Update()
    {
        if(CheckBattleReady() && canBattle)
        {
            Battle(battlingCards[0],battlingCards[1]);
        }
        canBattle = true;
    }

    public void Battle(CardInstance attacker, CardInstance defender)
    {
        Debug.Log("battle started");
        defender.healthInstanceCurrentHealth -= attacker.card.attack;
        attacker.healthInstanceCurrentHealth-= defender.card.attack;
        attacker.GetComponent<Attack>().canAttack = false;

        ClearBattlingCards();
        canBattle = false;
    }

    void ClearBattlingCards()
    {
        Debug.Log("Battle Finished");
        for (int i = 0; i < battlingCards.Length; i++)
        {
            battlingCards[i] = null;
        }
    }

    public bool CheckBattleReady()
    {
        return battlingCards[0] != null && battlingCards[1] != null;
    }
}



