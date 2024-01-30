using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Card")]
public class Card : ScriptableObject
{
    public int id;
    public string cardName;
    public Sprite artwork;
    public int manaCost;
    public int attack;
    public int health;
}
