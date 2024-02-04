using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawToHand : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;
    [SerializeField] Transform parent;

    public GameObject InstantiateInHand()
    {
        GameObject newCard = Instantiate(cardPrefab, parent);
        newCard.transform.SetParent(parent);
        return newCard;
    }
}