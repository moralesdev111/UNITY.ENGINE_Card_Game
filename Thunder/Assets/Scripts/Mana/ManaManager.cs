using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaManager : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;

    public bool GreenLight(Card card)
    {
        return gameSettings.currentMana >= card.manaCost; 
    }

    public int ManaDecrease(int amount)
    {
        return gameSettings.currentMana-= amount;
    }
}
