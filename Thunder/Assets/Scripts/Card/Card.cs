using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Cards")]
public class Card : ScriptableObject
{
    public string cardName;
    public Sprite artwork;
    public Sprite cardBack;
    public int manaCost;
    public int attack;
    public int health;

    public enum CardState
    {
        deck,
        hand,
        battlefield,
        discard
    }
     public CardState cardState;
}